namespace Server.Infrastructure.Extension;

public static class RegisterCustomJwtAuthenticationExtension
{
	public static void RegisterJwt(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
			 .AddJwtBearer(options =>
			 {
				 var sectetKey =
					new SymmetricSecurityKey(Encoding.UTF8.GetBytes
								(configuration["JwtSettings:Key"]!));

				 options.TokenValidationParameters = new TokenValidationParameters
				 {
					 ValidateIssuer = false,

					 ValidateAudience = false,

					 ValidateLifetime = true,

					 ValidateIssuerSigningKey = true,

					 IssuerSigningKey = sectetKey,
				 };


				 options.Events = new JwtBearerEvents
				 {
					 OnMessageReceived = async context =>
					 {
						 string? access_token = context.HttpContext.Request.Headers["Authorization"];

						 if (!string.IsNullOrEmpty(access_token))
						 {
							 context.Token = access_token;

							 return;
						 }

						 access_token = context.HttpContext.Request.Headers["access_token"];

						 if (!string.IsNullOrEmpty(access_token))
						 {
							 context.Token = access_token;

							 return;
						 }

						 context.Token = access_token;

						 await Task.CompletedTask;

					 },
					 OnTokenValidated = async context =>
					 {
						 var tokenValidator =
								context.HttpContext.RequestServices
									.GetRequiredService<IValidateTokenHelper>();

						 await tokenValidator.ExecuteAsync(context: context);
					 },
					 OnChallenge = async context =>
					 {
						 context.HandleResponse();

						 await CreateUnAuthorizeResult(response: context.Response);
					 }
				 };
			 });

		services.AddAuthorization();
	}

	public static async Task CreateUnAuthorizeResult(HttpResponse response)
	{
		response.StatusCode = (int)HttpStatusCode.Unauthorized;

		var result = new Response();

		result.AddMessage(message: nameof(HttpStatusCode.Unauthorized));

		result.ChangeStatusCode(httpStatusCode: HttpStatusCodeEnum.Unauthorized);

		await response.WriteAsJsonAsync(result);
	}
}

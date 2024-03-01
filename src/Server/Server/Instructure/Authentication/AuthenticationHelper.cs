namespace Server.Instructure.Authentication;

public class AuthenticationHelper : IAuthenticationHelper
{
    private IConfiguration? configuration { get; set; }

    public AuthenticationHelper(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string GenerateJsonWebToken(ResponseUserViewModel response)
    {
        var sercretKey =
            configuration!["JwtSettings:Key"];

        var securityKey =
            new SymmetricSecurityKey(key: Encoding.UTF8.GetBytes(sercretKey!));

        var credentials =
            new SigningCredentials(key: securityKey, algorithm: SecurityAlgorithms.HmacSha256);

        var claims =
            new List<Claim>
            {
                new Claim(type:ClaimTypes.NameIdentifier ,value:response.Id.ToString()),

                new Claim(type:ClaimTypes.Name ,value:response.FullName!),

                new Claim(type:ClaimTypes.Role ,value:response.RoleId.ToString()),

                new Claim(type:ClaimTypes.Email ,value:response.Email!),
            };

        var securityToken =
            new JwtSecurityToken(
                signingCredentials: credentials,
                    claims: claims, expires: DateTime.UtcNow.AddMinutes(value: 30));

        var token =
            new JwtSecurityTokenHandler().WriteToken(token: securityToken);

        return token;
    }
}

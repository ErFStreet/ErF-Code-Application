using Domain.ViewModels.UserToken;

namespace Server.Instructure.Authentication;

public class AuthenticationHelper : IAuthenticationHelper
{
    private readonly IUserTokenService userTokenService;

    private readonly IUnitOfWork unitOfWork;

    private IConfiguration? configuration { get; set; }

    public AuthenticationHelper(IConfiguration configuration, IUserTokenService userTokenService,
        IUnitOfWork unitOfWork)
    {
        this.configuration = configuration;

        this.userTokenService = userTokenService;

        this.unitOfWork = unitOfWork;
    }

    public async Task<string?> GenerateJsonWebToken(ResponseUserViewModel response)
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

        var userTokenViewModel = new CreateUserTokenViewModel
        {
            AccessToken = token,
            UserId = response.Id,
        };

        await userTokenService.CreateAsync(viewModel: userTokenViewModel);

        var result =
            await unitOfWork.SaveChangesAsync();

        if (result)
        {
            return token;
        }

        return null;
    }
}

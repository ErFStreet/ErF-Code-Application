namespace Server.Controllers;

[EnableCors("Cors")]
public class AuthenticationController : BaseController
{
    private readonly IAuthenticationHelper authenticationHelper;

    private readonly IUserService userService;

    private readonly IUnitOfWork unitOfWork;

    public AuthenticationController(IAuthenticationHelper authenticationHelper,
        IUserService userService, IUnitOfWork unitOfWork)
    {
        this.authenticationHelper = authenticationHelper;

        this.userService = userService;

        this.unitOfWork = unitOfWork;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<Response>> Register(RegisterUserViewModel viewModel)
    {
        var response =
            new Response();

        if (viewModel is null)
        {
            response.AddMessage(message: ResponseMessages.BadRequest);

            response.ChangeStatusCode(httpStatusCode: HttpStatusCodeEnum.BadRequest);

            return response;
        }

        await userService.RegisterAsync(viewModel: viewModel);

        var result =
            await unitOfWork.SaveChangesAsync();

        if (result)
        {
            response.AddMessage(message: ResponseMessages.Success);

            response.ChangeStatusCode(httpStatusCode: HttpStatusCodeEnum.Success);

            return response;
        }

        response.AddMessage(message: ResponseMessages.ServerError);

        response.ChangeStatusCode(httpStatusCode: HttpStatusCodeEnum.ServerProblem);

        return response;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<Result<string>>> Login(LoginUserViewModel viewModel)
    {
        var response =
             new Result<string>();

        if (viewModel is null)
        {
            response.AddMessage(message: ResponseMessages.BadRequest);

            response.ChangeStatusCode(httpStatusCode: HttpStatusCodeEnum.BadRequest);

            return response;
        }

        var result =
            await userService.LoginAsync(viewModel: viewModel);

        if (result is null)
        {
            response.AddMessage(message: ResponseMessages.NotFound);

            response.ChangeStatusCode(httpStatusCode: HttpStatusCodeEnum.NotFound);

            return response;
        }

        var token =
            authenticationHelper.GenerateJsonWebToken(loginResult: result);

        response.Value = token;

        return response;
    }
}

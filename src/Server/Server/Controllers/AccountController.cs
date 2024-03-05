namespace Server.Controllers;

public class AccountController : BaseController
{
    #region Fields
    private readonly IRoleService roleService;

    private readonly IUnitOfWork unitOfWork;
    #endregion /Fields

    #region Constructure
    public AccountController(IRoleService roleService, IUnitOfWork unitOfWork)
    {
        this.roleService = roleService;

        this.unitOfWork = unitOfWork;
    }
    #endregion /Constructure

    #region Post && Delete && Put
    [HttpPost("CreateRole")]
    public async Task<ActionResult<Response>> CreateRole(CreateRoleViewModel viewModel)
    {
        var response =
            new Response();

        await roleService.CreateAsync(viewModel);

        var result =
            await unitOfWork.SaveChangesAsync();


        if (result)
        {
            response.ChangeStatusCode(httpStatusCode: HttpStatusCodeEnum.Success);

            response.AddMessage(message: ResponseMessages.Success);

            return response;
        }

        response.ChangeStatusCode(httpStatusCode: HttpStatusCodeEnum.ServerProblem);

        response.AddMessage(message: ResponseMessages.ServerError);

        return response;
    }

    [HttpDelete("RemoveRole")]
    public async Task<ActionResult<Response>> Remove(int id)
    {
        var respone =
            new Response();

        if (id != 0)
        {
            await roleService.DeleteAsync(id: id);

            var result =
                await unitOfWork.SaveChangesAsync();

            if (result)
            {
                respone.ChangeStatusCode(HttpStatusCodeEnum.Success);

                respone.AddMessage(message: ResponseMessages.Success);

                return respone;
            }

            respone.ChangeStatusCode(HttpStatusCodeEnum.ServerProblem);

            respone.AddMessage(message: ResponseMessages.ServerError);

            return respone;
        }

        respone.ChangeStatusCode(HttpStatusCodeEnum.BadRequest);

        respone.AddMessage(message: ResponseMessages.BadRequest);

        return respone;
    }
    #endregion /Post && Delete && Put

    #region Get
    [HttpGet("Roles")]
	public async Task<ActionResult<Result<List<ListRoleViewModel>>>> Roles()
    {
        var result =
            new Result<List<ListRoleViewModel>>();

        result.Value =
            await roleService.GetRolesAsync();

        result.ChangeStatusCode(HttpStatusCodeEnum.Success);

        result.AddMessage(ResponseMessages.Success);

        return result;
    }
    #endregion /Get
}

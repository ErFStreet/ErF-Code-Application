namespace Server.Controllers;

public partial class AccountController : BaseController
{
    private readonly IRoleService roleService;

    private readonly IUnitOfWork unitOfWork;

    public AccountController(IRoleService roleService, IUnitOfWork unitOfWork)
    {
        this.roleService = roleService;

        this.unitOfWork = unitOfWork;
    }

    [HttpPost("CreateRole")]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleViewModel viewModel)
    {
        await roleService.CreateAsync(viewModel);

        var result =
            await unitOfWork.SaveChangesAsync();

        object apiResult;

        if (result)
        {
            apiResult = new
            {
                Message = "Successfuly Created !",
                StatusCode = 200,
            };

            return Ok(apiResult);
        }

        apiResult = new
        {
            Message = "Problem Try Again !",
            StatusCode = 404,
        };

        return BadRequest(apiResult);
    }
}

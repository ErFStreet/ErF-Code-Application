namespace Server.Controllers;

public class AccountController : BaseController
{
    private readonly IRoleService roleService;

    private readonly IUnitOfWork unitOfWork;

    public AccountController(IRoleService roleService, IUnitOfWork unitOfWork)
    {
        this.roleService = roleService;

        this.unitOfWork = unitOfWork;
    }

    [EnableCors("Cors")]
    [HttpPost("CreateRole")]
    public async Task<IActionResult> CreateRole(CreateRoleViewModel viewModel)
    {
        await roleService.CreateAsync(viewModel);

        var result =
            await unitOfWork.SaveChangesAsync();

        object response;

        if (result)
        {
            response = new
            {
                Message = "Successfuly Created !",
                StatusCode = 200,
            };

            return Ok(response);
        }

        response = new
        {
            Message = "Problem Try Again !",
            StatusCode = 404,
        };

        return BadRequest(response);
    }

    [EnableCors("Cors")]
    [HttpGet("Roles")]
    public async Task<IActionResult> Roles()
    {
        var response =
            await roleService.GetRolesAsync();

        return Ok(response);
    }
}

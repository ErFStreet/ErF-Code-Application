namespace Server.Controllers;

public class BlogController : BaseController
{
    #region Properties
    private readonly IBlogService blogService;

    private readonly IUnitOfWork unitOfWork;
    #endregion /Properties

    #region Contracture
    public BlogController(IBlogService blogService, IUnitOfWork unitOfWork)
    {
        this.blogService = blogService;
        this.unitOfWork = unitOfWork;
    }
    #endregion /Contracture

    #region Post & Put & Delete
    [HttpPost("CreateBlog")]
    public async Task<ActionResult<Response>> Create(CreateBlogViewModel viewModel)
    {
        var response = new Response();

        await blogService.CreateAsync(viewModel: viewModel);

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

    [HttpPut("EditBlog")]
    public async Task<ActionResult<Response>> Edit(EditBlogViewModel viewModel)
    {
        var response = new Response();

        await blogService.EditAsync(viewModel: viewModel);

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

    [HttpDelete("DeleteBlog")]
    public async Task<ActionResult<Response>> Delete(int id)
    {
        var response = new Response();

        await blogService.DeleteAsync(id: id);

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
    #endregion /Post & Put & Delete

    #region Get
    [HttpGet("Edit")]
    public async Task<ActionResult<Result<EditBlogViewModel>>> GetEdit(int id)
    {
        var response = new Result<EditBlogViewModel>();

        var result =
            await blogService.GetBlogForEditByIdAsync(id: id);

        if(result is null)
        {
            response.ChangeStatusCode(httpStatusCode: HttpStatusCodeEnum.NotFound);

            response.AddMessage(message: ResponseMessages.NotFound);
        }

        response.ChangeStatusCode(httpStatusCode: HttpStatusCodeEnum.Success);

        response.AddMessage(message: ResponseMessages.Success);

        response.Value = result;

        return response;
    }

    [HttpGet("Blogs")]
    public async Task<ActionResult<Result<List<ListBlogViewModel>>>> Blogs()
    {
        var response = new Result<List<ListBlogViewModel>>();

        response.ChangeStatusCode(httpStatusCode: HttpStatusCodeEnum.Success);

        response.AddMessage(message: ResponseMessages.Success);

        response.Value =
            await blogService.GetAllAsync();

        return response;
    }
    #endregion /Get
}

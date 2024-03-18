using Domain.ViewModels.Music;

namespace Server.Controllers;

public class MusicController : BaseController
{
    private readonly IMusicService musicService;

    private readonly IUnitOfWork unitOfWork;

    public MusicController(IMusicService musicService, IUnitOfWork unitOfWork)
    {
        this.musicService = musicService;

        this.unitOfWork = unitOfWork;
    }

    [HttpPost("CreateMusic")]
    public async Task<ActionResult<Response>> Create([FromBody] CreateMusicViewModel viewModel)
    {
        var response = new Response();

        await musicService.CreateAsync(viewModel: viewModel);

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

    [HttpPut("EditMusic")]
    public async Task<ActionResult<Response>> Edit([FromBody] EditMusicViewModel viewModel)
    {
        var response = new Response();

        await musicService.EditAsync(viewModel: viewModel);

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

    [HttpDelete("DeleteMusic")]
    public async Task<ActionResult<Response>> Delete(int id)
    {
        var response = new Response();

        await musicService.DeleteAsync(id: id);

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

    [HttpGet("Musics")]
    public async Task<ActionResult<Result<List<ListMusicViewModel>>>> Musics()
    {
        var response = new Result<List<ListMusicViewModel>>();

        response.Value =
            await musicService.GetAllAsync();

        response.ChangeStatusCode(httpStatusCode: HttpStatusCodeEnum.Success);

        response.AddMessage(message: ResponseMessages.Success);

        return response;
    }

    [HttpGet("EditMusic")]
    public async Task<ActionResult<Result<EditMusicViewModel>>> GetEdit(int id)
    {
        var response = new Result<EditMusicViewModel>();

        var music =
            await musicService.GetMusicForEditById(id: id);

        if (music is null)
        {
            response.ChangeStatusCode(httpStatusCode: HttpStatusCodeEnum.NotFound);

            response.AddMessage(message: ResponseMessages.NotFound);
        }

        response.Value = music;

        response.ChangeStatusCode(httpStatusCode: HttpStatusCodeEnum.Success);

        response.AddMessage(message: ResponseMessages.Success);

        return response;
    }
}

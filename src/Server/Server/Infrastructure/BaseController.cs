namespace Server.Infrastructure;

[ApiController]
[ApiVersion("1.0")]
[EnableCors("Cors")]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    public BaseController() : base()
    {
    }
}

namespace Server.Instructure;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    public BaseController() : base()
    {
    }
}

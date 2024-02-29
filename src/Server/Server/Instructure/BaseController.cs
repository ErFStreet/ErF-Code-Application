namespace Server.Instructure;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    public BaseController() : base()
    {
    }
}

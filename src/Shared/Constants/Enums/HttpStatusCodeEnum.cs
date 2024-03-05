namespace Constants.Enums;

public enum HttpStatusCodeEnum:int
{
    Success = 200,
    NotFound = 404,
    ServerProblem = 500,
    BadRequest = 400,
    Pending = 202,
	Unauthorized = 401,
}

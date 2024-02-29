namespace SoftMax.Result.Instructure;

public class Response
{
    public Response()
    {
        StatusCode = (int)HttpStatusCode.OK;

        Messages =
            new List<string>();
    }

    public Response(List<string> messages, HttpStatusCodeEnum httpStatusCode) : base()
    {
        Messages = messages;

        StatusCode = (int)httpStatusCode;
    }

    public int StatusCode { get; set; }

    public List<string> Messages { get; set; }

    public void AddMessage(string message)
    {
        Messages.Add(message);
    }

    public void ChangeStatusCode(HttpStatusCodeEnum httpStatusCode)
    {
        StatusCode = (int)httpStatusCode;
    }
}

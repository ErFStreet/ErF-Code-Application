namespace SoftMax.Result.Instructure;

public class Result<TValue> : Response
{
    public Result()
    {
            
    }

    public TValue? Value { get; set; }
}



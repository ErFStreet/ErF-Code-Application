namespace SoftMax.Result.Infrastructure;

public class Result<TValue> : Response
{
    public Result()
    {
            
    }

    public TValue? Value { get; set; }
}



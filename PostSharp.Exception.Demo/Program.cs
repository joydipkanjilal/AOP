using PostSharp.Aspects;


PostSharpHelper.TestExceptionAspect();

public static class PostSharpHelper
{
    [ExceptionAspect]
    public static void TestExceptionAspect()
    {
        throw new Exception("This is a test message");
    }
}

[Serializable]
public class ExceptionAspect : OnExceptionAspect
{
    public override void OnException(MethodExecutionArgs args)
    {
        Console.WriteLine("Error occured at: " +
        DateTime.Now.ToShortTimeString() + " Error Message: " +
        args.Exception.Message);
        args.FlowBehavior = FlowBehavior.Continue;
        base.OnException(args);
    }
}


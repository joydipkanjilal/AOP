using PostSharp.Aspects;

namespace PostSharp.Exception.Demo
{
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
}

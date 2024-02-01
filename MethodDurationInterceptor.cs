using Castle.DynamicProxy;
using System.Diagnostics;

namespace Autofac.Challenge.MethodExecutionDuration.Demo
{
    public class MethodDurationInterceptor : IInterceptor
    {
        TextWriter writer;
        public MethodDurationInterceptor(TextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            var declaringType = invocation.Method.DeclaringType;
            var methodName = invocation.Method.Name;

            //Before method execution
            var stopwatch = Stopwatch.StartNew();

            //Executing the actual method
            invocation.Proceed();

            //After method execution
            stopwatch.Stop();
            writer.WriteLine(
                "MeasureDurationInterceptor: {0} executed in {1} milliseconds.",
                invocation.MethodInvocationTarget.Name,
                stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                );
        }
    }
}

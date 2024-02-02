using Castle.DynamicProxy;
using System.Diagnostics;

namespace Autofac.Challenge.MethodDuration.Demo
{
    public class MethodDurationInterceptor : IInterceptor
    {
        private TextWriter writer;
        private static object lockObj = new object();
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
            lock(lockObj)
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
                    "The method {0} was executed in {1} milliseconds.",
                    invocation.MethodInvocationTarget.Name,
                    stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                    );
            }
        }
    }
}
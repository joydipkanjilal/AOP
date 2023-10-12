using Autofac;
using Autofac.Demo;

public class AutofacCustomModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DataManager>().As<IDataManager>().SingleInstance();
        //builder.RegisterType<DataManager>().As<IDataManager>().InstancePerDependency();
        //builder.RegisterType<DataManager>().As<IDataManager>().InstancePerRequest();
    }
}
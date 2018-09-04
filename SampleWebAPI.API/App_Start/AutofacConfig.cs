using Autofac;
using System.Web.Http;
using System.Reflection;
using SampleWebAPI.Data;
using Autofac.Integration.WebApi;
using SampleWebAPI.Data.Services;
using SampleWebAPI.Domain.IServices;
using SampleWebAPI.Domain.IRepositories;

namespace SampleWebAPI.API.App_Start
{
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterGeneric(typeof(GenericRepository<>))
                   .As(typeof(IGenericRepository<>))
                   .InstancePerRequest();
            
            builder.RegisterType<UserServices>()
                   .As<IUserServices>()
                   .InstancePerRequest();

            Container = builder.Build();

            return Container;
        }
    }
}
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Covid19.Morocco.Infrastructure;
using Covid19.Morocco.Repository;
using Covid19.Morocco.Service;
using System.Linq;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MultipartDataMediaFormatter;

namespace Covid19.Morocco.WebApi.Post
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }
        public static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(CityRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(CityService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Register Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.Formatters.Add(new FormMultipartEncodedMediaTypeFormatter());
        }
    }
}
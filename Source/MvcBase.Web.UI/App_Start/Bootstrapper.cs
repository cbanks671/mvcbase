using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using MvcBase.Data.Repository;
using MvcBase.Data.Infrastructure;
using MvcBase.Service;
using MvcBase.Mappings;
using MvcBase.Web.Core.Authentication;
using Microsoft.AspNet.Identity.EntityFramework;
using MvcBase.Model.Models;
using MvcBase.Data.Models;
using Microsoft.AspNet.Identity;

namespace MvcBase
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces().InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces().InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(typeof(DefaultFormsAuthentication).Assembly)
                   .Where(t => t.Name.EndsWith("Authentication"))
                   .AsImplementedInterfaces().InstancePerHttpRequest();

            builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MvcBaseEntities())))
                   .As<UserManager<ApplicationUser>>().InstancePerHttpRequest();

            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));                 
        }
    }
}
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using LoveMeBetter.Models;
using LoveMeBetter.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace LoveMeBetter
{
    public static class AutofacBootstrapper
    {
        private static readonly ContainerBuilder _builder = new ContainerBuilder();
        private static IContainer _container;

        public static IContainer GetContainer()
        {
            if (_container == null)
            {
                InitializeContainer();
            }
            return _container;
        }

        private static void InitializeContainer()
        {
            // Register your MVC controllers.
            _builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            _builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            _builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            _builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            _builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            _builder.RegisterFilterProvider();

            RegisterAppModules();

            _container = _builder.Build();
        }

        private static void RegisterAppModules()
        {
            // intance per lifetime works the same as per request here and are better for testing
            _builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerLifetimeScope();
            _builder.RegisterType<UserStore<ApplicationUser>>().AsImplementedInterfaces().InstancePerLifetimeScope(); 
            _builder.Register(c => new IdentityFactoryOptions<ApplicationUserManager>() { DataProtectionProvider = new DpapiDataProtectionProvider("LoveMeBetter") }); 
            _builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerLifetimeScope();
            _builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerLifetimeScope();

            _builder.RegisterType<ApplicationDbInitializer>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
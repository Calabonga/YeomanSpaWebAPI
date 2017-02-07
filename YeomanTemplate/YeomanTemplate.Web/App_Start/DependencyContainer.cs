using System;
using Autofac;
using Autofac.Integration.WebApi;
using Calabonga.Portal.Config;
using log4net;
using YeomanTemplate.Data;
using YeomanTemplate.Data.Base;
using YeomanTemplate.Web.Infrastructure.AppConfig;
using YeomanTemplate.Web.Infrastructure.Mapper.Base;
using YeomanTemplate.Web.Infrastructure.OAuth;
using YeomanTemplate.Web.Infrastructure.Services.Base;

namespace YeomanTemplate.Web {

    /// <summary>
    /// Default DependencyContainer for application
    /// </summary>
    public static class DependencyContainer {

        public static IContainer Initialize() {

            var builder = new ContainerBuilder();
            var assembly = typeof(Startup).Assembly;
            builder.RegisterApiControllers(assembly);

            builder.RegisterType<ApplicationDbContext>().As<IAppContext>();
            builder.RegisterType<AppConfig>().As<IAppConfig>();
            builder.RegisterType<CacheService>().As<ICacheService>();
            builder.RegisterType<JsonConfigSerializer>().As<IConfigSerializer>();
            builder.RegisterType<DefaultServiceSettings>().As<IServiceSettings>();
            builder.RegisterType<ApplicationOAuthProvider>().AsSelf().SingleInstance();

            builder.RegisterInstance(LogManager.GetLogger(typeof(Startup))).As<ILog>();

            //Mapper dependencies
            builder.RegisterGeneric(typeof(PagedListConverter<,>));

            // Global items registrations
            MapperRegistration.Register(builder);

            //// Register class by Name convention
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .InstancePerRequest();

            return builder.Build();

        }
    }
}
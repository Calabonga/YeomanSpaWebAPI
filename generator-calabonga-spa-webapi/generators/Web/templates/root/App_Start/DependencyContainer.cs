using System;
using Autofac;
using Autofac.Integration.WebApi;
using Calabonga.Portal.Config;
using log4net;
using <%= projectName %>.Data;
using <%= projectName %>.Data.Base;
using <%= projectName %>.Web.Infrastructure.AppConfig;
using <%= projectName %>.Web.Infrastructure.Mapper.Base;
using <%= projectName %>.Web.Infrastructure.OAuth;
using <%= projectName %>.Web.Infrastructure.Services.Base;

namespace <%= projectName %>.Web {

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
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .InstancePerRequest();

            return builder.Build();

        }
    }
}

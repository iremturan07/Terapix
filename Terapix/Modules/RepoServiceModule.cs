using System.Reflection;
using Autofac;
using Autofac.Core;
using Terapix.CORE.Services;
using Terapix.CORE.UnitOfWorks;
using Terapix.REPOSİTORY;
using Terapix.REPOSİTORY.Repositories;
using Terapix.REPOSİTORY.UnitOfWorks;
using Terapix.SERVICE.Mappings;
using Terapix.SERVICE.Services;
using Module = Autofac.Module;

namespace Terapix.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(GenericRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>))
                .InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWorks>().As<IUnitOfWorks>();
            builder.RegisterType<TokenHandler>().As<ITokenHandler>();

            var apiAssembly=Assembly.GetExecutingAssembly();
            var repoAssembly=Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly=Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

        }

    }
    
}

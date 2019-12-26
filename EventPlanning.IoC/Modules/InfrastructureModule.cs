using System.Configuration;
using EventPlanning.InfrastructureServices.Contexts;
using Microsoft.EntityFrameworkCore;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace EventPlanning.IoC.Modules
{   
    public class InfrastructureModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            var optionBuilder = new DbContextOptionsBuilder<MyContext>();
            optionBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MyContext"].ConnectionString);

            using (var context = new MyContext(optionBuilder.Options))
            {
                context.Database.EnsureCreated();
            }

            container.RegisterType<MyContext>(new HierarchicalLifetimeManager(),
                new InjectionConstructor(optionBuilder.Options));
        }
    }
}

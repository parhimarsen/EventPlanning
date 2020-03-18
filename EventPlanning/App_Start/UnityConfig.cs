using System.Web.Mvc;
using EventPlanning.IoC;
using EventPlanning.IoC.Modules;
using Unity;
using Unity.Mvc5;

namespace EventPlanning
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            Register<InfrastructureModule>(container);
            Register<DomainModule>(container);


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static void Register<T>(IUnityContainer container) where T : IModule, new()
        {
            new T().Register(container);
        }
    }
}
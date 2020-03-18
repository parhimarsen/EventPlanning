using System.Web.Http;
using EventPlanning.IoC;
using EventPlanning.IoC.Modules;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace EventPlanningWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            Register<InfrastructureModule>(container);
            Register<DomainModule>(container);

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public static void Register<T>(IUnityContainer container) where T : IModule, new()
        {
            new T().Register(container);
        }
    }
}
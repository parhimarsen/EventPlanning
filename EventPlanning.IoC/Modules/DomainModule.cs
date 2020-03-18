using EventPlanning.Domain.Interfaces;
using EventPlanning.DomainServices.Services;
using Unity;
using Unity.Lifetime;

namespace EventPlanning.IoC.Modules
{
    public class DomainModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IUsersService, UsersService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEventsService, EventsService>(new HierarchicalLifetimeManager());
            container.RegisterType<IFieldsService, FieldsService>(new HierarchicalLifetimeManager());
        }
    }
}

using Unity;

namespace EventPlanning.IoC
{
    public interface IModule
    {
        void Register(IUnityContainer container);
    }
}

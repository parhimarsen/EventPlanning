using EventPlanning.Infrastructure.Models;

namespace EventPlanning.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<InfrastructureUser> Users { get; }
        IGenericRepository<InfrastructureEvent> Events { get; }
        IGenericRepository<InfrastructureField> Fields { get; }
        IEventsFieldsRepository EventsFields { get; }
        void Save();
    }
}

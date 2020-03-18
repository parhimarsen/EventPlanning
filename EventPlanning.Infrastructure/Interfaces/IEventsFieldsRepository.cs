using System.Collections.Generic;
using System.Threading.Tasks;
using EventPlanning.Infrastructure.Models;

namespace EventPlanning.Infrastructure.Interfaces
{
    public interface IEventsFieldsRepository
    {
        Task<IEnumerable<InfrastructureField>> GetFieldsOfEvent(InfrastructureEvent @event);

        Task CreateField(InfrastructureEvent @event, InfrastructureField field);

        Task DeleteField(InfrastructureEvent @event, InfrastructureField field);

        Task DeleteEvent(InfrastructureEvent @event);
    }
}

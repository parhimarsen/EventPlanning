using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventPlanning.Domain.Models;

namespace EventPlanning.Domain.Interfaces
{
    public interface IEventsService
    {
        Task<IEnumerable<DomainEvent>> GetEvents();

        Task<DomainEvent> GetEvent(Guid eventId);

        Task<IEnumerable<DomainEvent>> GetEventsOfUser(DomainUser user);

        Task CreateEvent(DomainEvent @event);

        Task DeleteEvent(DomainEvent @event);

        Task UpdateEvent(DomainEvent @event);
    }
}

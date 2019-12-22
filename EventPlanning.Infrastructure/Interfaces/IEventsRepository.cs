using System.Collections.Generic;
using EventPlanning.Infrastructure.Models;

namespace EventPlanning.Infrastructure.Interfaces
{
    public interface IEventsRepository
    {
        IEnumerable<InfrastructureEvent> GetAllEvents();

        InfrastructureEvent GetEvent(int eventId);

        void CreateEvent(InfrastructureEvent @event);

        void DeleteEvent(int eventId);
    }
}

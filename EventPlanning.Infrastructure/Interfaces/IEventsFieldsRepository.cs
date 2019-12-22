

using System.Collections;
using System.Collections.Generic;
using EventPlanning.Infrastructure.Models;

namespace EventPlanning.Infrastructure.Interfaces
{
    public interface IEventsFieldsRepository
    {
        IEnumerable<InfrastructureField> GetAllFieldsOfEvent(int eventId);

        void CreateEventField(int eventId, int fieldId);

        void DeleteEvent(int eventId);

        void DeleteField(int fieldId);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventPlanning.Domain.Models;

namespace EventPlanning.Domain.Interfaces
{
    public interface IFieldsService
    {
        Task<IEnumerable<DomainField>> GetFields();

        Task<DomainField> GetField(Guid fieldId);

        Task<IEnumerable<DomainField>> GetFieldsOfEvent(DomainEvent @event);

        Task CreateField(DomainEvent @event,DomainField field);

        Task DeleteField(DomainEvent @event, DomainField field);

        Task UpdateField(DomainField field);
    }
}

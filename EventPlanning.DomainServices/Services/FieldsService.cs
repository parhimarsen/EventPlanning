using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlanning.Domain.Interfaces;
using EventPlanning.Domain.Models;
using EventPlanning.DomainServices.Mappers;
using EventPlanning.Infrastructure.Interfaces;

namespace EventPlanning.DomainServices.Services
{
    public class FieldsService : IFieldsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FieldsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DomainField>> GetFields()
        {
            var fields = await _unitOfWork.Fields.GetAll();

            return fields.Select(_ => _.ToDomain());
        }

        public async Task<DomainField> GetField(Guid fieldId)
        {
            var field = await _unitOfWork.Fields.Get(fieldId);

            return field.ToDomain();
        }

        public async Task<IEnumerable<DomainField>> GetFieldsOfEvent(DomainEvent @event)
        {
            var fields = await _unitOfWork.EventsFields.GetFieldsOfEvent(@event.ToInfrastructure());

            return fields.Select(_ => _.ToDomain());
        }


        public async Task CreateField(DomainEvent @event, DomainField field)
        {
            await _unitOfWork.Fields.Create(field.ToInfrastructure());
            await _unitOfWork.EventsFields.CreateField(@event.ToInfrastructure(), field.ToInfrastructure());
        }

        public async Task DeleteField(DomainEvent @event, DomainField field)
        {
            //await _unitOfWork.EventsFields.DeleteField(@event.ToInfrastructure(), field.ToInfrastructure());
            await _unitOfWork.Fields.Delete(field.ToInfrastructure());
        }

        public async Task UpdateField(DomainField field)
        {
            await _unitOfWork.Fields.Update(field.ToInfrastructure());
        }
    }
}

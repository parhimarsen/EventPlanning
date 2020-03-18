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
    public class EventsService : IEventsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DomainEvent>> GetEvents()
        {
            var events = await _unitOfWork.Events.GetAll();

            return events.Select(_ => _.ToDomain());
        }

        public async Task<DomainEvent> GetEvent(Guid eventId)
        {
            var @event = await _unitOfWork.Events.Get(eventId);

            return @event.ToDomain();
        }

        public async Task<IEnumerable<DomainEvent>> GetEventsOfUser(DomainUser user)
        {
            var @events = await GetEvents();

            return @events.Where(_ => _.UserId == user.Id);
        }

        public async Task CreateEvent(DomainEvent @event)
        {
            await _unitOfWork.Events.Create(@event.ToInfrastructure());
        }

        public async Task DeleteEvent(DomainEvent @event)
        {
            await _unitOfWork.EventsFields.DeleteEvent(@event.ToInfrastructure());
        }

        public async Task UpdateEvent(DomainEvent @event)
        {
            await _unitOfWork.Events.Update(@event.ToInfrastructure());
        }
    }
}

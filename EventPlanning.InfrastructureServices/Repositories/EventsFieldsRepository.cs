using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlanning.Infrastructure.Interfaces;
using EventPlanning.Infrastructure.Models;
using EventPlanning.InfrastructureServices.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventPlanning.InfrastructureServices.Repositories
{
    public class EventsFieldsRepository : IEventsFieldsRepository
    {
        private readonly MyContext _context;

        public EventsFieldsRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InfrastructureField>> GetFieldsOfEvent(InfrastructureEvent @event)
        {
            var _event = await _context.Events.Include(_ => _.EventsFields).ThenInclude(_ => _.Field)
                .FirstOrDefaultAsync(_ => _.Id == @event.Id);

            var fieldsOfEvent = _event.EventsFields.Select(_ => _.Field).ToList();

            return fieldsOfEvent;
        }

        public async Task CreateField(InfrastructureEvent @event, InfrastructureField field)
        {
            @event.EventsFields.Add(new InfrastructureEventFields { EventId = @event.Id, FieldId = field.Id });
            _context.EventsFields.Add(new InfrastructureEventFields {EventId = @event.Id, FieldId = field.Id });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteField(InfrastructureEvent @event, InfrastructureField field)
        {
            var _event = await _context.Events.Include(_ => _.EventsFields).FirstOrDefaultAsync(_ => _.Id == @event.Id);
            var _field = await _context.Fields.FirstOrDefaultAsync(_ => _.Id == field.Id);
            if (_event != null && _field != null)
            {
                var eventField = _event.EventsFields.FirstOrDefault(_ => _.EventId == _event.Id);
                _event.EventsFields.Remove(eventField);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEvent(InfrastructureEvent @event)
        {
            var _event = await _context.Events.Include(_ => _.EventsFields).FirstOrDefaultAsync(_ => _.Id == @event.Id);
            if (_event != null)
            {
                _context.Events.Remove(_event);
                var fieldsOfEvent = await GetFieldsOfEvent(@event);
                foreach (var field in fieldsOfEvent)
                {
                    _context.Fields.Remove(field);
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}

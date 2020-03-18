using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using EventPlanning.Domain.Interfaces;
using EventPlanningWebApi.Mappers;
using EventPlanningWebApi.Models;

namespace EventPlanningWebApi.Controllers
{
    [RoutePrefix("api/events")]
    public class EventController : ApiController
    {
        private readonly IEventsService _eventsService;
        private readonly IFieldsService _fieldsService;
        private readonly IUsersService _usersService;

        public EventController(IEventsService eventsService, IFieldsService fieldsService, IUsersService usersService)
        {
            _eventsService = eventsService;
            _fieldsService = fieldsService;
            _usersService = usersService;
        }

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            List<EventViewModel> modelView = new List<EventViewModel>();
            var events = await _eventsService.GetEvents();

            var eventsView = events.Select(_ => _.ToView());
            foreach (var e in eventsView)
            {
                var fieldsOfEvent = await _fieldsService.GetFieldsOfEvent(e.ToDomain());
                e.Fields = fieldsOfEvent.Select(_ => _.ToView());
                var userOfEvent = await _usersService.GetUserOfEvent(e.ToDomain());
                e.User = userOfEvent.ToView();
                modelView.Add(e);
            }
            return Ok(modelView);
        }

        [HttpGet, Route("{eventId:int}")]
        public async Task<IHttpActionResult> Get(Guid eventId)
        {
            var @event = await _eventsService.GetEvent(eventId);
            var modelView = @event.ToView();
            var fieldsOfEvent = await _fieldsService.GetFieldsOfEvent(modelView.ToDomain());
            modelView.Fields = fieldsOfEvent.Select(_ => _.ToView());
            var userOfEvent = await _usersService.GetUserOfEvent(modelView.ToDomain());
            modelView.User = userOfEvent.ToView();
            return Ok(modelView);
        }

        [HttpPost, Route("")]
        public async Task Create([FromBody] EventViewModel eventModel)
        {
            await _eventsService.CreateEvent(eventModel?.ToDomain());
            foreach (var field in eventModel.Fields)
            {
                await _fieldsService.CreateField(eventModel.ToDomain(), field.ToDomain());
            }
        }

        [HttpPut, Route("")]
        public async Task Edit([FromBody] EventViewModel eventModel)
        {
            await _eventsService.UpdateEvent(eventModel?.ToDomain());
        }

        [HttpDelete, Route("")]
        public async Task Delete([FromBody] EventViewModel eventModel)
        {
            await _eventsService.DeleteEvent(eventModel?.ToDomain());
        }
    }
}

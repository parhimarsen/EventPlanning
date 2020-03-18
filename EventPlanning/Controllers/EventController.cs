using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using EventPlanning.Domain.Interfaces;
using EventPlanning.Mappers;
using EventPlanning.Models;

namespace EventPlanning.Controllers
{
    public class EventController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IEventsService _eventsService;
        private readonly IFieldsService _fieldsService;

        public EventController(IEventsService eventsService, IFieldsService fieldsService, IUsersService usersService)
        {
            _eventsService = eventsService;
            _fieldsService = fieldsService;
            _usersService = usersService;
        }

        // GET: Event
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<EventViewModel> modelView = new List<EventViewModel>();
            var events = await _eventsService.GetEvents();

            var eventsView = events.Select(_ => _.ToView());
            foreach (var e in eventsView)
            {
                var fieldsOfEvent = await _fieldsService.GetFieldsOfEvent(e.ToDomain());
                e.Fields = fieldsOfEvent.Select(_ => _.ToView());
                var user = await _usersService.GetUserOfEvent(e.ToDomain());
                e.User = user.ToView();
                modelView.Add(e);
            }

            return View(modelView);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }


    }
}
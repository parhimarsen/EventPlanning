using System.Threading.Tasks;
using System.Web.Http;
using EventPlanning.Domain.Interfaces;
using EventPlanningWebApi.Mappers;
using EventPlanningWebApi.Models;

namespace EventPlanningWebApi.Controllers
{
    [RoutePrefix("api/fields")]
    public class FieldController : ApiController
    {
        private readonly IFieldsService _fieldsService;

        public FieldController(IFieldsService fieldsServcie)
        {
            _fieldsService = fieldsServcie;
        }

        [HttpPost, Route("")]
        public async Task Create([FromBody] EventFieldViewModel eventFieldModel)
        {
            var eventModel = eventFieldModel.Event;
            var fieldModel = eventFieldModel.Field;
            await _fieldsService.CreateField(eventModel.ToDomain(), fieldModel.ToDomain());
            //var fieldsOfEvent = await _fieldsService.GetFieldsOfEvent(eventModel.ToDomain());
            //return Ok(fieldsOfEvent);
        }

        [HttpDelete, Route("")]
        public async Task Delete([FromBody] EventFieldViewModel eventFieldModel)
        {
            var eventModel = eventFieldModel.Event;
            var fieldModel = eventFieldModel.Field;
            await _fieldsService.DeleteField(eventModel.ToDomain(), fieldModel.ToDomain());
        }

        [HttpPut, Route("")]
        public async Task Edit([FromBody] FieldViewModel fieldModel)
        {
            await _fieldsService.UpdateField(fieldModel?.ToDomain());
        }
    }
}

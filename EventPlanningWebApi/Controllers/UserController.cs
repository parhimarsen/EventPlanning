using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using EventPlanning.Domain.Interfaces;
using EventPlanningWebApi.Attributes;
using EventPlanningWebApi.Mappers;
using EventPlanningWebApi.Models;

namespace EventPlanningWebApi.Controllers
{
    [RoutePrefix("api/users")]
    //[CustomAuthorization("Admin", "User")]
    public class UserController : ApiController
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            var users = await _usersService.GetUsers();
            return Ok(users.Select(_ => _.ToView()));
        }

        //[AllowAnonymous]
        [HttpPost, Route("")]
        public async Task Create([FromBody] UserViewModel userModel)
        {
            await _usersService.CreateUser(userModel?.ToDomain());
        }

        [HttpGet, Route("{userId:int}")]
        public async Task<IHttpActionResult> Get(Guid userId)
        {
            var user = await _usersService.GetUser(userId);
            return Ok(user.ToView());
        }

        [HttpDelete, Route("")]
        public async Task Delete([FromBody] UserViewModel userModel)
        {
            await _usersService.DeleteUser(userModel?.ToDomain());
        }

        [HttpPut, Route("")]
        public async Task Update([FromBody] UserViewModel userModel)
        {
            await _usersService.UpdateUser(userModel?.ToDomain());
        }

    }
}

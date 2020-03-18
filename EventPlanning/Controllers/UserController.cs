using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using EventPlanning.Domain.Interfaces;
using EventPlanning.Mappers;
using EventPlanning.Models;

namespace EventPlanning.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var users = await _usersService.GetUsers();

            return View("Index", users.Select(_ => _.ToView()));
        }

        [HttpGet]
        public ActionResult User()
        {
            return View("CreateUser");
        }

        [HttpPost]
        public ActionResult User(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                _usersService.CreateUser(model.ToDomain());
                return RedirectToAction("Index", "User");
            }
            return View("CreateUser", model);
        }
    }
}
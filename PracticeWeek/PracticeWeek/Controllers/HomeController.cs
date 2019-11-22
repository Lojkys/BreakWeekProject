using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticeWeek.Models;
using PracticeWeek.Models.ViewModels;

namespace PracticeWeek.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService service;

        public HomeController(UserService service)
        {
            this.service = service;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("profile/{id}")]
        public IActionResult Profile([FromRoute] int id)
        {
            var user = service.UsersPostsAndTopics(id);
            return View(user);
        }

        [HttpPost("profile/{id}")]
        public IActionResult Profile([FromRoute] int id, string url, string username, string displayName)
        {
            var user = service.UpdateUser(id, url, username, displayName);
            return View(user);
        }

        [HttpGet("createaccount")]
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost("createaccount")]
        public IActionResult CreateAccount(User user)
        {
            if (service.DoesUserExist(user.Username))
            {
                var text = "Your account already exists, please log in with the same username.";
                return View("CreateAccount", text);
            }
            else
            {
                var newUser = service.NewUser(user);
                return RedirectToAction("home", new { id = newUser.ID });
            }
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            if (service.DoesUserExist(user.Username))
            {
                var currentUser = service.FindUserUsername(user.Username);
                return RedirectToAction("home", new { id = currentUser.ID });
            }
            else
            {
                var text = "You have to create a new account.";
                return View("index", text);
            }
        }

        [HttpPost("search/{id}")]
        public IActionResult Search(string search, [FromRoute] int id)
        {
            if (String.IsNullOrEmpty(search))
            {
                return RedirectToAction("home", new { id });
            }
            else
            {
                var modelView = new ModelViewHome();
                modelView.Topics = service.Search(search);
                modelView.User = service.FindUserByID(id);
                return View("search", modelView);
            }
        }

        [Route("home/{id}")]
        public IActionResult Home(int id)
        {
            var modelView = service.GetAll(id);           
            return View(modelView);
        }
    }
}
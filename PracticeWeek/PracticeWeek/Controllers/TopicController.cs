using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticeWeek.Models;
using PracticeWeek.Models.ViewModels;

namespace PracticeWeek.Controllers
{
    [Route("topic")]
    public class TopicController : Controller
    {
        private TopicService topicService;
        private UserService userService;

        public TopicController(TopicService service, UserService userService)
        {
            this.topicService = service;
            this.userService = userService;
        }

        [HttpPost("addpost/{username}/{id}")]
        public IActionResult AddPost([FromRoute] string username, [FromRoute] int id, string name, string content)
        {
            var user = userService.FindUserUsername(username);
            var topic = topicService.FindTopicByID(id);
            topicService.CreatePost(name, content, user, topic);

            return RedirectToAction("ViewTopic");
        }

        [HttpGet("viewtopic/{username}/{id}")]
        public IActionResult ViewTopic([FromRoute] string username, [FromRoute] int id)
        {
            var user = userService.FindUserUsername(username);
            var topic = topicService.FindTopicByID(id);
            var modelView = new UserTopicPosts();
            modelView.User = user;
            modelView.Topic = topic;
            modelView.Posts = topicService.GetAllPosts();
            return View(modelView);
        }

        [HttpGet("createtopic/{id}")]
        public IActionResult CreateTopic([FromRoute] int id)
        {
            var user = userService.FindUserByID(id);
            return View(user);
        }

        [HttpPost("createtopic/{id}")]
        public IActionResult CreateTopic(string name, [FromRoute] int id)
        {
            User user = userService.FindUserByID(id);
            topicService.CreateTopic(name, user);
            return RedirectToAction("home", "Home", user.ID);
        }
    }
}
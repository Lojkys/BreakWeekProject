using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWeek.Models.ViewModels
{
    public class UserTopicPosts
    {
        public User User { get; set; }
        public Topic Topic { get; set; }
        public List<Post> Posts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWeek.Models.ViewModels
{
    public class ModelViewHome
    {
        public User User { get; set; }
        public List<Topic> Topics { get; set; }
        public List<Post> Posts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWeek.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string URL { get; set; }
        public List<Topic> Topics { get; set; }
        public List<Post> Posts { get; set; }

        public User()
        {
            this.RegisterDate = DateTime.Now;
            Topics = new List<Topic>();
            Posts = new List<Post>();
        }
    }
}

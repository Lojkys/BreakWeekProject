using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWeek.Models
{
    public class Post
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string PostedBy { get; set; }
        public string PicUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public User User { get; set; }
        public Topic Topic { get; set; }
        public Post(string postedBy)
        {
            this.CreatedTime = DateTime.Now;
            this.PostedBy = postedBy;
        }
    }
}

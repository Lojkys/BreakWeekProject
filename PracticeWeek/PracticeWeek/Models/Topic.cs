using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWeek.Models
{
    public class Topic
    {
        [Key]
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public User User { get; set; }
        public List<Post> Posts { get; set; }

        public Topic(string createdBy)
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedBy = createdBy;
            Posts = new List<Post>();
        }
    }
}

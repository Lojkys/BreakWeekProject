using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWeek.Models
{
    public class TopicService
    {
        private ApplicationContext appContext;

        public TopicService(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }

        public void CreateTopic(string name, User user)
        {
            using (var context = appContext)
            {
                var newTopic = new Topic(user.Username);
                newTopic.Name = name;
                newTopic.User = user;
                context.Topics.Add(newTopic);
                user.Topics.Add(newTopic);
                context.SaveChanges();
            }
        }

        public Topic FindTopicByID(int topicId)
        {
            var topic = appContext.Topics.Find(topicId);
            return topic;
        }

        public void CreatePost(string name, string content, User user, Topic topic)
        {
            var newPost = new Post(user.Username);
            newPost.Name = name;
            newPost.Content = content;
            newPost.User = user;
            newPost.Topic = topic;
            newPost.PicUrl = user.URL;
            topic.Posts.Add(newPost);
            user.Posts.Add(newPost);
            appContext.Posts.Add(newPost);
            appContext.SaveChanges();
        }

        public List<Post> GetAllPosts()
        {
            return appContext.Posts.ToList();
        }
    }
}

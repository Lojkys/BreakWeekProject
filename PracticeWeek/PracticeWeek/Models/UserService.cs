using PracticeWeek.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWeek.Models
{
    public class UserService
    {
        private ApplicationContext appContext;

        public UserService(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }

        public List<User> ShowUsers()
        {
            var list = appContext.Users.ToList();
            return list;
        }

        public User NewUser(User user)
        {
            
            appContext.Users.Add(user);
            appContext.SaveChanges();
            return user;
            
        } 

        public User FindUserByID(int id)
        {
            var user = appContext.Users.Find(id);
            return user;
        }

        public User UsersPostsAndTopics(int id)
        {
            var user = appContext.Users.Find(id);
            user.Posts = appContext.Posts.Where(p => p.User.Username == user.Username).ToList();
            user.Topics = appContext.Topics.Where(p => p.User.Username == user.Username).ToList();
            return user;
        }

        public bool DoesUserExist(string username)
        {
            var user = appContext.Users.Any(u => u.Username.Equals(username));
            return user;
        }

        public User UpdateUser(int id, string url, string username, string displayName)
        {
            var user = FindUserByID(id);
            user.URL = url;
            user.Username = username;
            user.DisplayName = displayName;
            appContext.SaveChanges();
            user.Posts = appContext.Posts.Where(p => p.User.Username == user.Username).ToList();
            user.Topics = appContext.Topics.Where(p => p.User.Username == user.Username).ToList();
            return user;
        }

        public User FindUserUsername(string username)
        {
            var list = appContext.Users.ToList();
            var user = list.First(u => u.Username == username);
            return user;
        }

        public ModelViewHome GetAll(int id)
        {
            var modelView = new ModelViewHome();
            modelView.User = FindUserByID(id);
            modelView.Topics = appContext.Topics.ToList();
            modelView.Posts = appContext.Posts.ToList();
            return modelView;
        }

        public List<Post> GetAllPosts()
        {
            return appContext.Posts.ToList();
        }

        public List<Topic> Search(string search)
        {
            var result = appContext.Topics.Where(t => t.Name.Contains(search)).ToList();
            return result;
        }
    }
}

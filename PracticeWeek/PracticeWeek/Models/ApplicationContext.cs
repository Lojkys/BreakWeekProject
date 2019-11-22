using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWeek.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Topics);
            modelBuilder.Entity<User>().HasMany(u => u.Posts);
            modelBuilder.Entity<Topic>().HasOne(t => t.User);
            modelBuilder.Entity<Topic>().HasMany(t => t.Posts);
            modelBuilder.Entity<Post>().HasOne(t => t.User);
            modelBuilder.Entity<Post>().HasOne(t => t.Topic);
        }
    }
}

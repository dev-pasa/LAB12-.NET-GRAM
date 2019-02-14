using Microsoft.EntityFrameworkCore;
using NET_GRAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_GRAM.Data
{
    public class PostsDbContext : DbContext
    {

        public PostsDbContext(DbContextOptions<PostsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Posts>().HasData(
                new Posts
                {
                    ID = 1,
                    Title = "Chace's Pancake Coral",
                    Author = "Jimmy",
                    Capture = "Snow day",
                    ImageURL = "https://images.pexels.com/photos/688660/pexels-photo-688660.jpeg"
                },
                new Posts
                {
                    ID = 2,
                    Title = "Chace's Pancake Coral",
                    Author = "Bob",
                    Capture = "Snow",
                    ImageURL = "https://images.pexels.com/photos/688660/pexels-photo-688660.jpeg"
                }
                );
        }


        public DbSet<Posts> Post { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}

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
                    Title = "Street Coral View",
                    Author = "Jimmy",
                    Capture = "Snow day",
                    ImageURL = "https://images.pexels.com/photos/688660/pexels-photo-688660.jpeg"
                },
                new Posts
                {
                    ID = 2,
                    Title = "Snow on Top",
                    Author = "Bob",
                    Capture = "Snow",
                    ImageURL = "https://www.andersonsobelcosmetic.com/wp-content/uploads/2016/12/what-to-do-in-Seattle-for-the-holidays-family-activities-1024x684.jpg"
                },
                new Posts
                {
                    ID = 3,
                    Title = "View Needle",
                    Author = "Peter",
                    Capture = "Sun Set",
                    ImageURL = "https://images.pexels.com/photos/688660/pexels-photo-688660.jpeg"
                });


            modelBuilder.Entity<Comment>().HasData(
                 new Comment
                 {
                     ID = 1,
                     PostID = 1,
                     User = "Jimmy",
                     UserComment = "Beautiul Seattle"
                 },
                new Comment
                {
                    ID = 2,
                    PostID = 2,
                    User = "Bob",
                    UserComment = "Beautiul Seattle"

                },
                new Comment
                {
                    ID = 3,
                    PostID = 3,
                    User = "Peter",
                    UserComment = "The View is Amazon Amazing!"
                });
        }


        public DbSet<Posts> Post { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}

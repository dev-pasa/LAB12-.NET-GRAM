using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NET_GRAM.Models;
using NET_GRAM.Migrations;
using NET_GRAM.Pages;
using NET_GRAM.Data;
using Microsoft.EntityFrameworkCore;
using NET_GRAM.Models.Services;
using Microsoft.EntityFrameworkCore.InMemory;

namespace XUnitTestProject1.GetSet
{
    public class gettersetter
    {
        /// <summary>
        /// Set the Author property for Posts
        /// </summary>
        [Fact]
        public void GetAuthor()
        {
            Posts post = new Posts();

            post.Author = "First";

            Assert.Equal("First", post.Author);
        }

        /// <summary>
        /// reSet the Author property for Posts
        /// </summary>
        [Fact]
        public void SetAuthor()
        {
            Posts post = new Posts();
            post.Author = "First";

            post.Author = "Second";

            Assert.Equal("Second", post.Author);
        }

        /// <summary>
        /// Set the Image property for Posts
        /// </summary>
        [Fact]
        public void CanGetImageURL()
        {
            Posts post = new Posts();

            post.ImageURL = "test.img";

            Assert.Equal("test.img", post.ImageURL);
        }

        /// <summary>
        /// ReSet the Author property for Posts
        /// </summary>
        [Fact]
        public void SetImageURL()
        {
            Posts post = new Posts();
            post.ImageURL = "test1.img";

            post.ImageURL = "test2.img";

            Assert.Equal("test2.img", post.ImageURL);
        }

        /// <summary>
        /// Set the Capture property for Posts
        /// </summary>
        [Fact]
        public void GetCapture()
        {
            Posts post = new Posts();
            post.Capture = "test1";
            Assert.Equal("test1", post.Capture);
        }

        /// <summary>
        /// ReSet the Author property for Posts
        /// </summary>
        [Fact]
        public void SetCapture()
        {
            Posts post = new Posts();
            post.Capture = "test1";
            post.Capture = "test12";
            Assert.Equal("test12", post.Capture);
        }

        /// <summary>
        /// Set the Title property for Posts
        /// </summary>
        [Fact]
        public void GetTitle()
        {
            Posts post = new Posts();
            post.Title = "test1";
            Assert.Equal("test1", post.Title);
        }

        /// <summary>
        /// ReSet the Author property for Posts
        /// </summary>
        [Fact]
        public void SetTitle()
        {
            Posts post = new Posts();
            post.Title = "test1";
            post.Title = "test12";
            Assert.Equal("test12", post.Title);
        }

        /// <summary>
        /// Set the URL property for Posts
        /// </summary>
        [Fact]
        public void GetUserID()
        {
            Posts post = new Posts();

            post.ID = 1;

            Assert.Equal(1, post.ID);
        }

        /// <summary>
        /// Set the ID property for Posts
        /// </summary>
        [Fact]
        public void SetUserID()
        {
            Posts post = new Posts();

            post.ID = 1;
            post.ID = 2;

            Assert.Equal(2, post.ID);
        }

        /// <summary>
        /// Set the PostID property for Posts
        /// </summary>
        [Fact]
        public void GetPostID()
        {
            Comment comment = new Comment();

            comment.PostID = 1;

            Assert.Equal(1, comment.PostID);
        }

        /// <summary>
        /// Update Post ID
        /// </summary>
        [Fact]
        public void CanPostID()
        {
            Comment comment = new Comment();
            comment.PostID = 1;

            comment.PostID = 2;

            Assert.Equal(2, comment.PostID);
        }

        /// <summary>
        /// Test user property
        /// </summary>
        [Fact]
        public void GetUser()
        {
            Comment comment = new Comment();

            comment.User = "Test";

            Assert.Equal("Test", comment.User);
        }

        /// <summary>
        /// Update USer
        /// </summary>
        [Fact]
        public void SetUser()
        {
            Comment comment = new Comment();
            comment.User = "Test";

            comment.User = "Test2";

            Assert.Equal("Test2", comment.User);
        }

        /// <summary>
        /// Get User comment
        /// </summary>
        [Fact]
        public void GetUserComment()
        {
            Comment comment = new Comment();

            comment.UserComment = "Test";

            Assert.Equal("Test", comment.UserComment);
        }

        /// <summary>
        /// Update user comment
        /// </summary>
        [Fact]
        public void SetUserComment()
        {
            Comment comment = new Comment();
            comment.UserComment = "Test";

            comment.UserComment = "Test2";

            Assert.Equal("Test2", comment.UserComment);
        }

       
    }
}

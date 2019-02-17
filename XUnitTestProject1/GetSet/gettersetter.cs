using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NET_GRAM.Models;

namespace XUnitTestProject1.GetSet
{
    public class gettersetter
    {
        [Fact]
        public void GetAuthor()
        {
            Posts post = new Posts();

            post.Author = "First";

            Assert.Equal("First", post.Author);
        }


        [Fact]
        public void SetAuthor()
        {
            Posts post = new Posts();
            post.Author = "First";

            post.Author = "Second";

            Assert.Equal("Second", post.Author);
        }

        [Fact]
        public void CanGetImageURL()
        {
            Posts post = new Posts();

            post.ImageURL = "test.img";

            Assert.Equal("test.img", post.ImageURL);
        }

        [Fact]
        public void SetImageURL()
        {
            Posts post = new Posts();
            post.ImageURL = "test1.img";

            post.ImageURL = "test2.img";

            Assert.Equal("test2.img", post.ImageURL);
        }


        [Fact]
        public void GetCapture()
        {
            Posts post = new Posts();
            post.Capture = "test1";
            Assert.Equal("test1", post.Capture);
        }

        [Fact]
        public void SetCapture()
        {
            Posts post = new Posts();
            post.Capture = "test1";
            post.Capture = "test12";
            Assert.Equal("test12", post.Capture);
        }


        [Fact]
        public void GetTitle()
        {
            Posts post = new Posts();
            post.Title = "test1";
            Assert.Equal("test1", post.Title);
        }

        [Fact]
        public void SetTitle()
        {
            Posts post = new Posts();
            post.Title = "test1";
            post.Title = "test12";
            Assert.Equal("test12", post.Title);
        }

        [Fact]
        public void CanGetUserID()
        {
            Posts post = new Posts();

            post.ID = 1;

            Assert.Equal(1, post.ID);
        }

        [Fact]
        public void SetUserID()
        {
            Posts post = new Posts();

            post.ID = 1;
            post.ID = 2;

            Assert.Equal(2, post.ID);
        }

        [Fact]
        public void CanGetPostID()
        {
            Comment comment = new Comment();

            comment.PostID = 1;

            Assert.Equal(1, comment.PostID);
        }

        [Fact]
        public void CanSetPostID()
        {
            Comment comment = new Comment();
            comment.PostID = 1;

            comment.PostID = 2;

            Assert.Equal(2, comment.PostID);
        }

        [Fact]
        public void GetUser()
        {
            Comment comment = new Comment();

            comment.User = "Test";

            Assert.Equal("Test", comment.User);
        }

        [Fact]
        public void SetUser()
        {
            Comment comment = new Comment();
            comment.User = "Test";

            comment.User = "Test2";

            Assert.Equal("Test2", comment.User);
        }

        [Fact]
        public void GetUserComment()
        {
            Comment comment = new Comment();

            comment.UserComment = "Test";

            Assert.Equal("Test", comment.UserComment);
        }

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

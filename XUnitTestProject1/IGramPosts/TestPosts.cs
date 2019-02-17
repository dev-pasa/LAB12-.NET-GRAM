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

namespace XUnitTestProject1.IGramPosts
{
    public class TestPosts
    {
        /// <summary>
        /// Create a post 
        /// </summary>
        [Fact]
        public async void CreatePost()
        {
            DbContextOptions<PostsDbContext> options = new DbContextOptionsBuilder<PostsDbContext>().UseInMemoryDatabase("CreatePost").Options;


            using (PostsDbContext context = new PostsDbContext(options))
            {
                Posts post = new Posts();
                post.Author = "Cat";
                post.ImageURL = "test.img";
                post.Title = "Seattle";

                PostsManager postService = new PostsManager(context);
                await postService.SaveAsync(post);
                Posts result = await context.Post.FirstOrDefaultAsync(h => h.ID == post.ID);

                Assert.Equal(post, result);
            }
        }

        /// <summary>
        /// Check GetSinglePost method
        /// </summary>
        [Fact]
        public async void ReadSinglePost()
        {
            DbContextOptions<PostsDbContext> options = new DbContextOptionsBuilder<PostsDbContext>().UseInMemoryDatabase("ReadPost").Options;

            using (PostsDbContext context = new PostsDbContext(options))
            {
                PostsManager postService = new PostsManager(context);
                Posts post = new Posts();
                post.Author = "Cat";
                post.ImageURL = "test.img";
                post.Title = "Seattle";
                await postService.SaveAsync(post);

                Posts result = await postService.GetSinglePost(post.ID);

                Assert.Equal(post, result);
            }
        }

        /// <summary>
        /// Create empty post
        /// </summary>
        [Fact]
        public async void CreateEmptyPost()
        {
            DbContextOptions<PostsDbContext> options = new DbContextOptionsBuilder<PostsDbContext>().UseInMemoryDatabase("CreateEmptyPost").Options;

            using (PostsDbContext context = new PostsDbContext(options))
            {
                Posts post = new Posts();

                PostsManager postService = new PostsManager(context);
                await postService.SaveAsync(post);
                Posts result = await context.Post.FirstOrDefaultAsync(h => h.ID == post.ID);

                Assert.Null(result.Author);
            }
        }

        /// <summary>
        /// Get a list of post
        /// </summary>
        [Fact]
        public async void GetAllPosts()
        {
            DbContextOptions<PostsDbContext> options = new DbContextOptionsBuilder<PostsDbContext>().UseInMemoryDatabase("GetAllPosts").Options;

            using (PostsDbContext context = new PostsDbContext(options))
            {
                PostsManager postService = new PostsManager(context);
                Posts post = new Posts();
                post.Author = "Cat";
                post.ImageURL = "test.img";
                post.Title = "Seattle";
                await postService.SaveAsync(post);

                Posts postTwo = new Posts();
                post.Author = "Cats";
                post.ImageURL = "test.img";
                post.Title = "Seattle2";
                await postService.SaveAsync(postTwo);

                Posts postThree = new Posts();
                post.Author = "Cat3";
                post.ImageURL = "test.img";
                post.Title = "Seattle3";
                await postService.SaveAsync(postThree);

                var result = await postService.GetPosts();
                int count = result.Count;

                Assert.Equal(3, count);
            }
        }

        /// <summary>
        /// Edit a post
        /// </summary>
        [Fact]
        public async void EditPost()
        {
            DbContextOptions<PostsDbContext> options = new DbContextOptionsBuilder<PostsDbContext>().UseInMemoryDatabase("ChangePosts").Options;

            using (PostsDbContext context = new PostsDbContext(options))
            {
                PostsManager postService = new PostsManager(context);
                Posts post = new Posts();
                post.Author = "Cat";
                post.ImageURL = "test.img";
                post.Title = "Seattle";
                await postService.SaveAsync(post);

                Posts post2 = new Posts();
                post.Author = "Cat";
                post.ImageURL = "test.img";
                post.Title = "Tacoma";
                await postService.SaveAsync(post);
                Posts result = await context.Post.FirstOrDefaultAsync(h => h.ID == post.ID);

                Assert.Equal("Tacoma", result.Title);
            }
        }

        /// <summary>
        /// Delete a post
        /// </summary>
        [Fact]
        public async void DeletePost()
        {
            DbContextOptions<PostsDbContext> options = new DbContextOptionsBuilder<PostsDbContext>().UseInMemoryDatabase("ChangePosts").Options;

            using (PostsDbContext context = new PostsDbContext(options))
            {
                PostsManager postService = new PostsManager(context);
                Posts post = new Posts();
                post.Author = "Cat";
                post.ImageURL = "test.img";
                post.Title = "Seattle";
                await postService.SaveAsync(post);

                Posts post2 = new Posts();
                post.Author = "Cat";
                post.ImageURL = "test.img";
                post.Title = "Tacoma";
                await postService.SaveAsync(post);
                

                await postService.Delete(post2.ID);
                var result = await context.Post.FirstOrDefaultAsync(p => p.ID == post2.ID);

                Assert.Null(result);
            }
        }
    }
}

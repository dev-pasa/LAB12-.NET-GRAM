using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NET_GRAM.Models;
using NET_GRAM.Models.Interfaces;
using NET_GRAM.Models.Util;

namespace NET_GRAM.Pages.Grams
{
    public class ManageModel : PageModel
    {
        private readonly IGram _post;

        //private object configuration;

        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public Posts Post { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        

        public ManageModel(IGram post)
        {
            _post = post;
            //Blob Storage Account to be referenced
            //BlobImage = new Blob(configuration);
        }

        public async void OnGet()
        {
            Post = await _post.GetSinglePost(ID.GetValueOrDefault()) ?? new Posts();
        }

        public async Task<IActionResult> OnPost()
        {
            // Make the call to our DB with our ID.
            var pos = await _post.GetSinglePost(ID.GetValueOrDefault()) ?? new Posts();

            // set the data from the database to the new data 
            pos.Author = Post.Author;
            pos.Capture = Post.Capture;
            pos.Title = Post.Title;
            // Save the restaurant in the database
            await _post.SaveAsync(pos);

            return RedirectToPage("/Grams/Index", new { id = pos.ID });
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _post.Delete(ID.Value);
            return RedirectToPage("/Index");
        }

    }
}
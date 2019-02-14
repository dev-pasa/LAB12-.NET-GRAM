using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NET_GRAM.Models;
using NET_GRAM.Models.Interfaces;

namespace NET_GRAM.Pages.Grams
{
    public class ManageModel : PageModel
    {
        private readonly IGram _post;

        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public Posts Post { get; set; }


        public ManageModel(IGram post)
        {
            _post = post;
        }

        public async void OnGet()
        {
            Post = await _post.FindPost(ID.GetValueOrDefault()) ?? new Posts();
        }

        public async Task<IActionResult> OnPost()
        {
            // Make the call to our DB with our ID.
            var pos = await _post.FindPost(ID.GetValueOrDefault()) ?? new Posts();

          

            // set the data from the database to the new data from Restaurant/user input
            pos.Author = Post.Author;
            pos.Capture = Post.Capture;
            pos.Title = pos.Title;

            // Save the restaurant in the database
            await _post.SaveAsync(pos);

            return RedirectToPage("/Grams/Index", new { id = pos.ID });
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _post.DeleteAsync(ID.Value);
            return RedirectToPage("/Index");
        }

    }
}
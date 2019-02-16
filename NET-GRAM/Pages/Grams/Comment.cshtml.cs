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
    public class CommentModel : PageModel
    {
        private readonly IComment _comment;

        public CommentModel(IComment comment)
        {
            _comment = comment;
        }

        [FromRoute]
        public int ID { get; set; }

        [BindProperty]
        public Comment Comment { get; set; }


        public void OnGet()
        {
            Comment = new Comment();
        }

        public async Task<IActionResult> OnPost()
        {
            var comment = new Comment();
            comment.PostID = ID;
            comment.User = comment.User;
            comment.UserComment = Comment.UserComment;

            await _comment.SaveAsync(comment);
            return RedirectToPage("/Grams/Index", ID);

        }

    }


}

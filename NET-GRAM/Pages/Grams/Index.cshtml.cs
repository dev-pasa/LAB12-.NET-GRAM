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
    public class IndexModel : PageModel
    {

        private readonly IGram _post;

        public IndexModel(IGram post)
        {
            _post = post;
        }

        [FromRoute]
        public int ID { get; set; }
        public Posts Post { get; set; }


        public async Task OnGet()
        {
            // set all the data for my .cshtml page.

            // Get the specific Restaurant data for the id that was sent. 
            Post = await _post.GetSinglePost(ID);
        }
    }
} 
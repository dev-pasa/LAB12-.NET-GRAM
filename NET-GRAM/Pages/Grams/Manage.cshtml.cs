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
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;


namespace NET_GRAM.Pages.Grams
{
    public class ManageModel : PageModel
    {
        private readonly IGram _post;

        public Blob BlobImage { get; }

        //private object configuration;

        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public Posts Post { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        

        public ManageModel(IGram post, IConfiguration configuration) 
        {
            _post = post;
            //Blob Storage Account to be referenced
           BlobImage = new Blob(configuration);
        }

        public async void OnGet()
        {
            Post = await _post.GetSinglePost(ID.GetValueOrDefault()) ?? new Posts();
        }

        public async Task<IActionResult> OnPost()
        {
            // Make the call to our DB with our ID.
            var post = await _post.GetSinglePost(ID.GetValueOrDefault()) ?? new Posts();

            // set the data from the database to the new data 
            post.Author = Post.Author;
            post.ImageURL = Post.ImageURL;
            post.Capture = Post.Capture;

            if(Image != null)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                //Get Container
                var container = await BlobImage.GetContainer("images");
                //upload the image
                BlobImage.UploadFile(container, Image.FileName, filePath);

                CloudBlob blob = await BlobImage.GetBlob(Image.FileName, container.Name);

                //update the db image for the post
                post.ImageURL = blob.Uri.ToString();
            }

            // Save the post in the database
            await _post.SaveAsync(post);

            return RedirectToPage("/Grams/Index", new { id = post.ID });
        }


        public async Task<IActionResult> OnPostDelete()
        {
            await _post.Delete(ID.Value);
            return RedirectToPage("/Index");
        }

    }
}
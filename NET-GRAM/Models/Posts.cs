using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_GRAM.Models
{
    public class Posts
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Capture { get; set; }

        public string ImageURL { get; set; }

        public List<Comment> Comments { get; set; }
    }
}

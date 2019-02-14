using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_GRAM.Models
{
    public class Comment
    {
        public int ID { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public int PostID { get; set; }

        public Posts Post { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task_WebAndCloud.Models
{
    public class Post
    {
        public int PostId { get; set; }
        [Required(ErrorMessage = "Please enter a title for your post")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please insert some content for your post")]
        public string Content { get; set; } 
        public DateTime PostingDate{ get; set; }
        [Required(ErrorMessage = "Please insert a category according to your content")]
        public string Category { get; set; }
        public string UserEmail { get; set; }
    }
}

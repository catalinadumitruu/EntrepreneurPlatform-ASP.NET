using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_WebAndCloud.Models;

namespace Task_WebAndCloud.ViewModels
{
    public class PostsListViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}

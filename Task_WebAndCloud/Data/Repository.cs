using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_WebAndCloud.Models;

namespace Task_WebAndCloud.Data
{
    public class Repository : IPostsRepository
    {
        private ApplicationDbContext context;

        public Repository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Post> Posts
        {
            get
            {
                return context.Posts;
            }
        }

        public IQueryable<User> Users
        {
            get
            {
                return context.Users;
            }
        }

        public async Task SavePostAsync(Post post)
        {
            if (post.PostId == 0)
            {
                context.Posts.Add(post);
            }
            else
            {
                Post dbEntry = context.Posts
                    .FirstOrDefault(p => p.PostId == post.PostId);
                if (dbEntry != null)
                {
                    dbEntry.Title = post.Title;
                    dbEntry.Content = post.Content;
                    dbEntry.PostingDate = post.PostingDate;
                    dbEntry.Category = post.Category;
                }
            }
            await context.SaveChangesAsync();
        }

        public async Task<Post> DeleteProductAsync(int postID)
        {
            Console.WriteLine("About to delete post with id " + postID);
            Post dbEntry = context.Posts
            .Where(p => p.PostId == postID).FirstOrDefault();

            if (dbEntry != null)
            {
                context.Posts.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            Console.WriteLine("Deleted");
            return dbEntry;
        }

        public async Task<User> DeleteUserAsync(string Email)
        {
            Console.WriteLine("About to delete user with email " + Email);
            User dbEntry = context.Users
            .Where(u => u.Email == Email).FirstOrDefault();

            if (dbEntry != null)
            {
                context.Users.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            Console.WriteLine("Deleted");
            return dbEntry;
        }
    }
}

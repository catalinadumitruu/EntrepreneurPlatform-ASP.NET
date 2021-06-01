using System.Linq;
using System.Threading.Tasks;
using Task_WebAndCloud.Models;

namespace Task_WebAndCloud.Data
{
    public interface IPostsRepository
    {
        IQueryable<Post> Posts { get; }

        Task SavePostAsync(Post post);

        Task<Post> DeleteProductAsync(int postID);

    }
}

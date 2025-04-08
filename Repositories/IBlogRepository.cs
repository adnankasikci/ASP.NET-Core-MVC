using AppSpace.Models;

namespace AppSpace.IRepositories
{
    public interface IBlogRepository
    {
        Task<List<Blogs>> AllBlogs();
        Task<Blogs> GetBlogByIdAsync(int id);
        Task AddBlog(Blogs blog);
        Task DeleteBlogAsync(int id);
    }
}


// Task<Blogs> GetBlogByIdAsync(int id);
// Task<IEnumerable<Blogs>> GetAllBlogsAsync();
// Task AddBlogAsync(Blogs blog);
// Task UpdateBlogAsync(Blogs blog);
// Task DeleteBlogAsync(int id);
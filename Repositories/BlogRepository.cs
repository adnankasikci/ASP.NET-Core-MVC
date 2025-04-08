using AppSpace.Db;
using AppSpace.IRepositories;
using AppSpace.Models;
using Microsoft.EntityFrameworkCore;

namespace AppSpace.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationContext _context;

        public BlogRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Blogs>> AllBlogs()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blogs> GetBlogByIdAsync(int id)
        {
            return await _context.Blogs
                .FirstOrDefaultAsync(b => b.Id == id)
                ?? throw new Exception("Blog bulunamadı.");
        }

        public async Task AddBlog(Blogs blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBlogAsync(int id)
        {
            var blog = await GetBlogByIdAsync(id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
        }
    }
}



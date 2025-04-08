using AppSpace.Db;
using AppSpace.IRepositories;
using AppSpace.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyAspNetProject.Namespace
{

    [Route("admin/blog/[action]")]
    public class AdminBlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public AdminBlogController(ApplicationContext context, IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IActionResult> Show()
        {
            var blogs = await _blogRepository.AllBlogs();
            return View("~/Views/Admin/Blogs/Index.cshtml", blogs);
        }

        public IActionResult Add()
        {
            return View("~/Views/Admin/Blogs/BlogAdd.cshtml");
        }

    }
}

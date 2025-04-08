using Microsoft.AspNetCore.Mvc;

namespace MyAspNetProject.Namespace
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("blog/{id}")]
        public IActionResult BlogDetay(int id)
        {
            return View(id);
        }
    }
}

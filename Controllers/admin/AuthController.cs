using Microsoft.AspNetCore.Mvc;
using AppSpace.Services;
using Microsoft.EntityFrameworkCore;
using AppSpace.Db;
using AppSpace.Helpers;
using AppSpace.Models;
using AppSpace.IRepositories;

namespace MyAspNetProject.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;
        private readonly ApplicationContext _context;
        private readonly IBlogRepository _blogRepository;

        public AuthController(JwtTokenService jwtTokenService, ApplicationContext context, IBlogRepository blogRepository)
        {
            _jwtTokenService = jwtTokenService;
            _context = context;
            _blogRepository = blogRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Kullanıcı adı ve parola gereklidir.");
            }

            var author = await _context.Author.FirstOrDefaultAsync(auth => auth.Name == request.Username);

            if (author == null)
            {
                RedirectToAction("login", new { author?.Id });
                return Unauthorized("Yetkisiz Ad");
            }

            if (author.Password == request.Password)
            {
                var token = _jwtTokenService.GenerateJwtToken(author.Name, author.Surname, author.Email);
                return Ok(new { token });
            }

            return Unauthorized("Hatalı parola");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddBlog([FromForm] BlogRequest postBlog, [FromForm] IFormFile blog_photo)
        {
            if (postBlog == null || blog_photo == null)
            {
                return BadRequest("Geçersiz blog verisi.");
            }

            var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "blogs");

            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(blog_photo.FileName);
            var filePath = Path.Combine(uploadsDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await blog_photo.CopyToAsync(stream);
            }

            var blog = new Blogs
            {
                Title = postBlog.Title,
                Subtitle = postBlog.Subtitle,
                Content = postBlog.Content,
                ImagePath = "/img/blogs/" + fileName,
                Url = postBlog.Url
            };

            await _blogRepository.AddBlog(blog);

            return Ok(new { message = "Blog başarıyla eklendi." });
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteBlog([FromBody] DeleteBlogRequest request)
        {
            try
            {
                if (request == null || request.BlogId <= 0)
                    return BadRequest("Geçersiz blog ID.");

                var blog = await _blogRepository.GetBlogByIdAsync(request.BlogId);

                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", blog.ImagePath?.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                await _blogRepository.DeleteBlogAsync(request.BlogId);

                return Ok(new { message = "Blog başarıyla silindi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata oluştu: {ex.Message}");
            }
        }

        [HttpGet("BlogAll")]
        public async Task<IActionResult> BlogAll()
        {
            try
            {
                var blogs = await _blogRepository.AllBlogs();

                if (blogs == null || !blogs.Any())
                    return NotFound("Hiç blog bulunamadı.");

                return Ok(blogs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata oluştu: {ex.Message}");
            }
        }

        [HttpPost("getBlogId")]
        public async Task<IActionResult> getBlogId([FromBody] DeleteBlogRequest request)
        {
            try
            {
                var blogs = await _blogRepository.GetBlogByIdAsync(request.BlogId);

                if (blogs == null || request.BlogId <= 0)
                    return NotFound("Hiç blog bulunamadı.");

                return Ok(blogs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata oluştu: {ex.Message}");
            }
        }



    }
}




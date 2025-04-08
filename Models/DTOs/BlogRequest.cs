namespace AppSpace.Models
{
    public class BlogRequest
    {
        public required string Title { get; set; }
        public required string Subtitle { get; set; }
        public required string Content { get; set; }
        public required string Url { get; set; }
        public string? ImagePath { get; set; }
    }

    public class DeleteBlogRequest
    {
        public required int BlogId { get; set; }
    }
}

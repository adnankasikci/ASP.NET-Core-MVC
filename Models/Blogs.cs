namespace AppSpace.Models
{
    public class Blogs
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Subtitle { get; set; }
        public required string Content { get; set; }
        public required string ImagePath { get; set; }
        public required string Url { get; set; }
    }
}

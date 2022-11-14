using System.ComponentModel.DataAnnotations;

namespace DotBlog.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? AuthorId { get; set; }
        public virtual Author? Author { get; set; }
    }
}
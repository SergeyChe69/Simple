using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DotBlog.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string? Name { get; set; }
        public virtual Post[]? Posts { get; set; }
    }
}
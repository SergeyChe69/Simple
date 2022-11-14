using DotBlog.Models;
using DotBlog.Models.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class DetailModel : PageModel
    {
        public Post Post { get; set; }
        private readonly IRepository _repository;
        public DetailModel(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult OnGet(string title)
        {
            Post = _repository.GetPost(title);
            if (Post == null)
            {
                return NotFound("this post was't found");
            }
            return Page();
        }
    }
}

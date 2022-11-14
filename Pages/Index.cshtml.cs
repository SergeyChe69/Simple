using DotBlog.Models;
using DotBlog.Models.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotBlog.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IRepository _repository;
    public IQueryable<Post> Posts { get; set; }
    public IndexModel(ILogger<IndexModel> logger, IRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public IActionResult OnGetAsync()
    {
        Posts = _repository.GetAll();
        return Page();
    }
}

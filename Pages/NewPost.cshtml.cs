using DotBlog.Models;
using DotBlog.Models.Actions;
using DotBlog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class NewPostModel : PageModel
    {
        private readonly IRepository _repository;
        public NewPostModel(IRepository repository)
        {
            _repository = repository;
        }
        public async Task OnPostAsync(string title, string content)
        {
            PostViewModel newPost = new PostViewModel();
            newPost.Title = title;
            newPost.Content = content;
            await _repository.AddPost(newPost);
        }
    }
}

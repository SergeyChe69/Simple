using DotBlog.Models.ViewModels;

namespace DotBlog.Models.Actions
{
    public interface IRepository
    {
         public IQueryable<Post> GetAll();
         public Post GetPost(string title);
         public Task AddPost(PostViewModel newPost);
    }
}
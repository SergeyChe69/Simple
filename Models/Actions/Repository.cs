using DotBlog.Helpers;
using DotBlog.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DotBlog.Models.Actions
{
    public class Repository : IRepository
    {
        private DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public Task AddPost(PostViewModel newPost)
        {
            Post addedPost = new Post
            {
                Title = newPost.Title,
                Content = newPost.Content
            };
            _context.Posts.Add(addedPost);
            _context.SaveChanges();
            
            return Task.CompletedTask;
        }

        public IQueryable<Post> GetAll()
        {
            return _context.Posts;
        }

        public Post GetPost(string title)
        {
            return _context.Posts.FirstOrDefault(post => post.Title == title);
        }
    }
}
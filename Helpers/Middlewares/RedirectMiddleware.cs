namespace DotBlog.Helpers.Middlewares
{
    public class RedirectMiddleware
    {
        private readonly RequestDelegate _next;
        public RedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        // Redirect from 'Privacy' to 'Index' response
        public async Task InvokeAsync(HttpContext context)
        {
            string url = context.Request.PathBase;
            if(context.Request.Path == "/Privacy")
            {
                context.Response.Redirect("/Index");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
using DotBlog.Helpers;
using DotBlog.Helpers.Middlewares;
using DotBlog.Models.Actions;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddDbContext<IdentityContext>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseMiddleware<RedirectMiddleware>();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();

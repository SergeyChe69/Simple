using DotBlog.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        [BindProperty]
        public RegisterViewModel UsersInput { get; set; }

        public RegisterModel(UserManager<IdentityUser> usrManager,
                             SignInManager<IdentityUser> inManager)
        {
            userManager = usrManager;
            signInManager = inManager;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                IdentityUser newUser = new IdentityUser
                {
                    UserName = UsersInput.Email,
                    Email = UsersInput.Email
                };
                var result = await userManager.CreateAsync(newUser, UsersInput.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(newUser, false);
                    return RedirectToAction("/NewPost");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("errors", error.Description);
                }
            }
            return  Page();
        }
    }
}

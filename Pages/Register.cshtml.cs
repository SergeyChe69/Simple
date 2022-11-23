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

        public RegisterModel(UserManager<IdentityUser> usrManager,
                        SignInManager<IdentityUser> inManager)
        {
            userManager = usrManager;
            signInManager = inManager;
        }

        public void OnGet()
        {
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityUser newUser = new IdentityUser
                {
                    Email = model.Email
                };
                var result = await userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(newUser, false);
                    return RedirectToAction("/NewPost");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }
    }
}

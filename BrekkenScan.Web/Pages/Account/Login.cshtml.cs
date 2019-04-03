using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BrekkenScan.Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var result = await signInManager.PasswordSignInAsync(Name, Password, isPersistent: true, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(Name), "Invalid request!");
                return Page();
            }

            return Redirect("/");
        }

        public void OnGet()
        {

        }
    }
}
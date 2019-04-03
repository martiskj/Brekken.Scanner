using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BrekkenScan.Web.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPost()
        {
            return Page();
        }

        private async Task<IActionResult> Register()
        {
            var user = new IdentityUser { UserName = Name };
            var result = await userManager.CreateAsync(user, Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: true);
                return Redirect("/");
            }

            foreach (var e in result.Errors)
            {
                ModelState.AddModelError(nameof(Password), e.Description);
            }

            return Page();
        }

        public void OnGet()
        {
        }
    }
}
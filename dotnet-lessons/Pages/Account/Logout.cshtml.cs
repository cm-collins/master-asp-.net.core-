using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace dotnet_lessons.Pages.Account
{



    public class LogoutModel : PageModel
    {
        public LogoutModel()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Logic for handling logout can be added here
            await HttpContext.SignOutAsync("MyCookieAuthentication");
            return RedirectToPage("/Index");
        }



    }
}
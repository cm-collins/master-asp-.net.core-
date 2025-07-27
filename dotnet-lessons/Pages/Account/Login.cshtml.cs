//explanation of the IAuthentication Interface in . net through  the Abstraction method
// The IAuthentication interface in .NET is part of the ASP.NET Core framework and provides a
// way to handle user authentication. It defines methods for signing in, signing out, and checking
// if a user is authenticated. This interface is typically implemented by authentication handlers,
// which are responsible for managing the authentication process, such as validating credentials,
// issuing tokens, and maintaining user sessions. The abstraction allows developers to create custom
// authentication schemes while adhering to a consistent interface, making it easier to integrate
// different authentication mechanisms (like cookies, JWT, etc.) into ASP.NET Core applications.    
// The IAuthentication interface is not directly used in the code above, but it is part of the
// underlying authentication system that the HttpContext.SignInAsync method interacts with.
// The code above implements a simple login page using Razor Pages in ASP.NET Core. It defines a

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace dotnet_lessons.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; } = new Credential();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Credential.UserName == "admin" && Credential.Password == "password")
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "admin"),
                new Claim(ClaimTypes.Email, "admin@example.com"),
                new Claim ("Department", "Hr"),
                new Claim ("Admin", "true"),
                new Claim("Manager","true"),
                new Claim("EmploymentDate", DateTime.Now.ToString("yyyy-MM-dd"))
            };

                var identity = new ClaimsIdentity(claims, "MyCookieAuthentication");
                var claimsPrincipal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = Credential.RememberMe // Set persistent cookie if Remember Me is checked
                };

                await HttpContext.SignInAsync("MyCookieAuthentication", claimsPrincipal, authProperties);

                return RedirectToPage("/Index"); // Redirect to home page after successful login
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page(); // Return view again to show error
        }

    }

    public class Credential
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; } = false;

        
    }

}


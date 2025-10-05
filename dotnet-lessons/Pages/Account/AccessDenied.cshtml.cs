using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_lessons.Pages.Account
{
    public class AccessDeniedModel : PageModel
    {
        private readonly ILogger<AccessDeniedModel> _logger;

        public AccessDeniedModel(ILogger<AccessDeniedModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("Access denied page visited.");
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace dotnet_lessons.Pages
{
            [Authorize(Policy = "AdminOnly")]

    public class SettingsModel : PageModel
    {
        // private readonly ILogger<SettingsModel> _logger;

        public SettingsModel(ILogger<SettingsModel> logger)
        {
            // _logger = logger;
        }

        public void OnGet()
        {
            // _logger.LogInformation("Admin settings Page viewed");
        }

    }
}
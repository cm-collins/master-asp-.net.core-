using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet_lessons.Pages
{
    [Authorize(Policy = "MustBelongToHrDepartment")]
    public class HumanResourceModel : PageModel
    {
        private readonly ILogger<HumanResourceModel> _logger;

        public HumanResourceModel(ILogger<HumanResourceModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("Human Resource page visited.");
        }

        public void OnPost()
        {
            // Handle form submission or other post actions here
        }
    }
}

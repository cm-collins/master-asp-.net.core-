using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace dotnet_lessons.Pages
{
    [Authorize(Policy = "HRManagerOnly")]
    public class HrManagerModel : PageModel
    {

        public void OnGet()
        {
            
        }

    }
}
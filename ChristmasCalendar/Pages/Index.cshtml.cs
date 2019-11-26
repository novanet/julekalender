using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ChristmasCalendar.Data;
using System;
using ChristmasCalendar.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ChristmasCalendar.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IDatabaseQueries _databaseQueries;

        public IndexModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IDatabaseQueries databaseQueries)
        {
            _signInManager = signInManager;
            _databaseQueries = databaseQueries;
            _userManager = userManager;
        }

        public Door TodaysDoor { get; set; }

        public Door NextDoor { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;

            TodaysDoor = (await _databaseQueries.GetTodaysDoor(DateTime.Today));

            NextDoor = (await _databaseQueries.GetNextDoor(DateTime.Today));

            if (TodaysDoor == null)
                return Page();

            bool hasOpenedTodaysDoor = await _databaseQueries.HasOpenedDoor(_userManager.GetUserId(HttpContext.User), TodaysDoor.Id);

            if (hasOpenedTodaysDoor)
                return LocalRedirect(Url.GetLocalUrl("/Doors/Today"));

            return Page();
        }       
    }
}

using Microsoft.AspNetCore.Mvc.RazorPages;
using ChristmasCalendar.Data;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChristmasCalendar.Pages.Doors
{
    public class TodayModel : PageModel
    {
        public Door Door { get; set; } //Support multiple doors for one day

        public DateTime TimeWhenDoorWasOpened { get; set; }

        [BindProperty]
        public AnswerViewModel AnswerInput { get; set; }

        public IList<RegisteredAnswerViewModel> RegisteredAnswers { get; set; }

        public string ReturnUrl { get; set; }

        private readonly IDatabaseQueries _databaseQueries;

        private readonly IDatabasePersister _databasePersister;

        private readonly UserManager<ApplicationUser> _userManager;

        public TodayModel(IDatabaseQueries databaseQueries, IDatabasePersister databasePersister, UserManager<ApplicationUser> userManager)
        {
            _databaseQueries = databaseQueries;
            _databasePersister = databasePersister;
            _userManager = userManager;

            Door = null;
            RegisteredAnswers = new List<RegisteredAnswerViewModel>();
        }

        public async Task OnGetAsync()
        {
            string userId = _userManager.GetUserId(HttpContext.User);

            Door = await _databaseQueries.GetTodaysDoor(DateTime.Today);

            if (Door == null)
                return;

            FirstTimeOpeningDoor firstTimeOpeningDoor = await _databaseQueries.GetFirstTimeOpeningDoor(userId, Door.Id);
            
            if (firstTimeOpeningDoor == null)
            {
                await _databasePersister.RegisterFirstTimeOpeningDoor(userId, Door);

                TimeWhenDoorWasOpened = DateTime.Now;
            }
            else
            {
                TimeWhenDoorWasOpened = firstTimeOpeningDoor.When;

                RegisteredAnswers = (await _databaseQueries.GetRegisteredAnswersForDoor(userId, Door.Id))
                    .Select(x => new RegisteredAnswerViewModel { When = x.When, Country = x.Country, Location = x.Location })
                    .ToList();
            }
        }

        public async Task<IActionResult> OnPostRegisterAnswerAsync(string returnUrl = null)
        {
            if (!ModelState.IsValid)
                return Page();

            await _databasePersister.RegisterAnswer(_userManager.GetUserId(HttpContext.User), AnswerInput.Location, AnswerInput.Country, DateTime.Now);

            return LocalRedirect(Url.GetLocalUrl(returnUrl));
        }
    }
}
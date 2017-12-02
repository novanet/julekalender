using ChristmasCalendar.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChristmasCalendar.Pages.Highscore
{
    public class HighscoreModel : PageModel
    {
        public IList<HighscoreViewModel> Scores { get; set; }

        public DateTime? LastUpdated { get; set; }

        private readonly IDatabaseQueries _databaseQueries;

        private UserManager<ApplicationUser> _userManager;

        public HighscoreModel(IDatabaseQueries databaseQueries, UserManager<ApplicationUser> userManager)
        {
            _databaseQueries = databaseQueries;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            var scoresFromDb = await _databaseQueries.GetScores();

            Scores = scoresFromDb
                .Select(x => new HighscoreViewModel
                {
                    NameOfUser = x.NameOfUser,
                    Points = x.Points,
                    Bonus = x.Bonus,
                    Rank = scoresFromDb.Where(y => y.TotalPoints > x.TotalPoints).Count() + 1
                })
                .OrderBy(x => x.Rank)
                .ThenBy(x => x.NameOfUser)
                .ToList();

            var lastUpdated = (await _databaseQueries.GetWhenScoreWasLastUpdated());

            LastUpdated = lastUpdated != DateTime.MinValue ? lastUpdated : (DateTime?)null;
        }
    }
}
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
            Scores = await _databaseQueries.GetScores(DateTime.Now.Year);

            //Scores = scoresFromDb
            //    .Select(x => new HighscoreViewModel
            //    {
            //        NameOfUser = x.NameOfUser,
            //        Points = x.Points,
            //        Bonus = x.Bonus,
            //        Rank = x.Rank,
            //        //Rank = scoresFromDb.Count(y => y.TotalPoints * 1000000 + y.Points * 100000 - y.AverageSecondsSpentPerCorrectDoor > x.TotalPoints * 1000000 + x.Points * 100000 - x.AverageSecondsSpentPerCorrectDoor) + 1,
            //        AverageSecondsSpentPerCorrectDoor = x.AverageSecondsSpentPerCorrectDoor
            //    })
            //    .OrderBy(x => x.Rank)
            //    .ThenBy(x => x.NameOfUser)
            //    .ToList();

            var lastUpdated = (await _databaseQueries.GetWhenScoreWasLastUpdated());

            LastUpdated = lastUpdated != DateTime.MinValue ? lastUpdated : (DateTime?)null;
        }
    }
}
using ChristmasCalendar.Pages.Highscore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChristmasCalendar.Data
{
    public class DatabaseQueries : IDatabaseQueries
    {
        private readonly ApplicationDbContext _context;

        public DatabaseQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Door>> GetHistoricDoors(DateTime now)
        {
            return _context.Doors
                .Where(x => x.ForDate < now)
                .OrderByDescending(x => x.ForDate)
                .ToListAsync();
        }

        public Task<List<Answer>> GetRegisteredAnswersForDoor(string userId, int doorId)
        {
            return _context.Answers
                .Where(x => x.DoorId == doorId && x.UserId == userId)
                .OrderByDescending(x => x.When)
                .ToListAsync();
        }

        public Task<List<HighscoreViewModel>> GetScores()
        {
            return _context.DailyScore
                .Include(c => c.ApplicationUser)
                .GroupBy(x => x.ApplicationUser)
                .Select(x => new HighscoreViewModel
                {
                    NameOfUser = x.Key.Name,
                    Points = x.Sum(y => y.Points),
                    Bonus = x.Sum(y => y.Bonus)
                })
                .OrderByDescending(x => x.TotalPoints)
                .ToListAsync();
        }

        public Task<Door> GetTodaysDoor(DateTime today)
        {
            return _context.Doors.SingleOrDefaultAsync(x => x.ForDate == today);
        }

        public Task<bool> HasOpenedDoor(string userId, int doorId)
        {
            return _context.FirstTimeOpeningDoor.AnyAsync(x => x.UserId == userId && x.DoorId == doorId);
        }

        public Task<FirstTimeOpeningDoor> GetFirstTimeOpeningDoor(string userId, int doorId)
        {
            return _context.FirstTimeOpeningDoor.SingleOrDefaultAsync(x => x.UserId == userId && x.DoorId == doorId);
        }

        public Task<DateTime> GetWhenScoreWasLastUpdated()
        {
            return _context.DailyScoreLastUpdated.Select(x => x.LastUpdated).SingleOrDefaultAsync();
        }
    }
}

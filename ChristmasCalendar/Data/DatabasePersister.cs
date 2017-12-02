using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChristmasCalendar.Data
{
    public class DatabasePersister : IDatabasePersister
    {
        private readonly ApplicationDbContext _context;

        public DatabasePersister(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RegisterAnswer(string userId, string location, string country, DateTime now)
        {
            _context.Answers.Add(Answer.Create(userId, _context.Doors.Single(x => x.ForDate == now.Date).Id, location, country, now));

            await _context.SaveChangesAsync();
        }

        public async Task RegisterFirstTimeOpeningDoor(string userId, Door door)
        {
            _context.FirstTimeOpeningDoor.Add(FirstTimeOpeningDoor.Create(userId, door.Id));

            await _context.SaveChangesAsync();
        }
    }
}

using System;
using System.Threading.Tasks;

namespace ChristmasCalendar.Data
{
    public interface IDatabasePersister
    {
        Task RegisterFirstTimeOpeningDoor(string userId, Door doorForToday);
        Task RegisterAnswer(string userId, string location, string country, DateTime when);
    }
}

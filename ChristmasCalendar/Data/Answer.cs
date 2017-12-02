using System;
using System.ComponentModel.DataAnnotations;

namespace ChristmasCalendar.Data
{
    public class Answer
    {
        public int Id { get; protected set; }

        public int DoorId { get; protected set; }

        [MaxLength(450)]
        public string UserId { get; protected set; }

        [MaxLength(100)]
        public string Location { get; protected set; }

        [MaxLength(100)]
        public string Country { get; protected set; }

        public bool LocationIsCorrect { get; protected set; }

        public bool CountryIsCorrect { get; protected set; }

        public DateTime When { get; protected set; }

        public static Answer Create(string userId, int doorId, string location, string country, DateTime when)
        {
            return new Answer
            {
                DoorId = doorId, 
                UserId = userId,
                Location = location,
                Country = country,
                LocationIsCorrect = false,
                CountryIsCorrect = false,
                When = when

            };
        }
    }
}

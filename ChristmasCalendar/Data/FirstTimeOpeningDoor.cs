using System;
using System.ComponentModel.DataAnnotations;

namespace ChristmasCalendar.Data
{
    public class FirstTimeOpeningDoor
    {
        public int Id { get; protected set; }

        [MaxLength(450)]
        public string UserId { get; protected set; }

        public int DoorId { get; protected set; }

        public DateTime When { get; protected set; }

        public static FirstTimeOpeningDoor Create(string userId, int doorId)
        {
            return new FirstTimeOpeningDoor
            {
                UserId = userId,
                DoorId = doorId,
                When = DateTime.Now
            };
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChristmasCalendar.Data
{
    public class DailyScore
    {
        public int Id { get; set; }

        public int DoorId { get; set; }

        [MaxLength(450)]

        public string UserId { get; set; }

        public int Points { get; set; }

        public int Bonus { get; set; }

        public int Rank { get; set; }

        public int RankMovement { get; set; }

        public int TimeToAnswer { get; set; }

        public int Year { get; set; }

        public string NameOfUser { get; set; }
    }
}

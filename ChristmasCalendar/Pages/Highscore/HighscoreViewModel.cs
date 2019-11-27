namespace ChristmasCalendar.Pages.Highscore
{
    public class HighscoreViewModel
    {
        public string NameOfUser { get; set; }

        public int Rank { get; set; }

        public int Points { get; set; }

        public int Bonus { get; set; }

        public int NumberOfCorrectDoors { get; set; }

        public int TotalTimeToAnswer { get; set; }

        public int TotalPoints => Points + Bonus;

        public int AverageSecondsSpentPerCorrectDoor { get; set; }
        public int PointsLastDoor { get; set; }
        public int PointsTotal { get; set; }
    }
}

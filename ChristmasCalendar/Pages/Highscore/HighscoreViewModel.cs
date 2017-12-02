namespace ChristmasCalendar.Pages.Highscore
{
    public class HighscoreViewModel
    {
        public string NameOfUser { get; set; }

        public int Rank { get; set; }

        public int Points { get; set; }

        public int Bonus { get; set; }

        public int TotalPoints => Points + Bonus;
    }
}

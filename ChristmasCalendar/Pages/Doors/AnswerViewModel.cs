using System.ComponentModel.DataAnnotations;

namespace ChristmasCalendar.Pages.Doors
{
    public class AnswerViewModel
    {
        [MaxLength(100)]
        public string Location { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }
    }
}

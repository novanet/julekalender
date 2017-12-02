using System;
using System.ComponentModel.DataAnnotations;

namespace ChristmasCalendar.Data
{
    public class Door
    {
        public int Id { get; protected set; }

        public int Number { get; protected set; }

        public DateTime ForDate { get; protected set; }

        [MaxLength(100)]
        public string Location { get; protected set; }

        [MaxLength(100)]
        public string Country { get; protected set; }

        public string ImagePath { get; protected set; }

        [MaxLength(200)]
        public string Description { get; protected set; }
    }
}

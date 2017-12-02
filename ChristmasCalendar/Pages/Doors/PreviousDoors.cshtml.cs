using ChristmasCalendar.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChristmasCalendar.Pages.Doors
{
    public class PreviousDoorsModel : PageModel
    {
        public IList<Door> PreviousDoors { get; set; }

        private readonly IDatabaseQueries _databaseQueries;

        public PreviousDoorsModel(IDatabaseQueries databaseQueries)
        {
            _databaseQueries = databaseQueries;
        }

        public async Task OnGetAsync()
        {
            PreviousDoors = await _databaseQueries.GetHistoricDoors(DateTime.Today);
        }
    }
}
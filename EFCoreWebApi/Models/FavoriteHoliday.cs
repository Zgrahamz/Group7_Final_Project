using System;

namespace Group7_Final_Project.EFCoreWebApi.Models
{
    public class FavoriteHoliday
    {
        public int Id { get; set; }
        public string HolidayName { get; set; } = string.Empty;
        public DateTime DateCelebrated { get; set; }
        public string Country { get; set; } = string.Empty;
        public bool IsPublicHoliday { get; set; }
        public string TypicalTraditions { get; set; } = string.Empty;
    }
}

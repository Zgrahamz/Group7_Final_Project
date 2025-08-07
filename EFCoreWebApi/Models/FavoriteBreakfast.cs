using System;

namespace Group7_Final_Project.EFCoreWebApi.Models
{
    public class FavoriteBreakfast
    {
        public int Id { get; set; }
        public string FoodName { get; set; } = string.Empty;
        public bool IsSweet { get; set; }
        public int TypicalCalories { get; set; }
        public string Category { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; }
    }
}

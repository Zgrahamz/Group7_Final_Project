using System;

namespace Group7_Final_Project.EFCoreWebApi.Models
{
    public class FavoritePlanet
    {
        public int Id { get; set; }
        public string PlanetName { get; set; } = string.Empty;
        public string Allegiance { get; set; } = string.Empty;
        public DateTime AllegianceDate { get; set; }
        public string Species { get; set; } = string.Empty;
        public string PlanetarySystem { get; set; } = string.Empty;
        public string Geography { get; set; } = string.Empty;
    }
}
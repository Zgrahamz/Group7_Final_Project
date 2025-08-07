//using EFCoreWebApi.Models;


//using Group7_Final_Project.EFCoreWebApi.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Group7_Final_Project.EFCoreWebApi.Data
//{
//    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
//    {
//        public AppDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext> options)
//            : base(options)
//        {
//        }
//        //public Microsoft.EntityFrameworkCore.DbSet<Group7_Final_Project.EFCoreWebApi.Models.Models.TeamMember> TeamMembers { get; set; }
//        //public DbSet<Group7_Final_Project.EFCoreWebApi.Models.Models.FavoriteBreakfast> FavoriteBreakfasts { get; set; }
//        //public DbSet<Group7_Final_Project.EFCoreWebApi.Models.Models.FavoriteHoliday> FavoriteHolidays { get; set; }

//        public DbSet<TeamMember> TeamMembers { get; set; }
//        public DbSet<FavoriteBreakfast> FavoriteBreakfasts { get; set; }
//        public DbSet<FavoriteHoliday> FavoriteHolidays { get; set; }
//    }
//}

using Group7_Final_Project.EFCoreWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Group7_Final_Project.EFCoreWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<FavoriteBreakfast> FavoriteBreakfasts { get; set; }
        public DbSet<FavoriteHoliday> FavoriteHolidays { get; set; }
    }
}
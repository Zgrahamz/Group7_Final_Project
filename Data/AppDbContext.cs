namespace EFCoreWebApi.Data
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public Microsoft.EntityFrameworkCore.DbSet<EFCoreWebApi.Models.TeamMember> TeamMembers { get; set; }
    }
}


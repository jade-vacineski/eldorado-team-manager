using Microsoft.EntityFrameworkCore;
using TeamManager.Domain.Entities;

namespace TeamManager.DataAccess.EF
{
    public class TeamManagerDbContext : DbContext
    {
        public TeamManagerDbContext(DbContextOptions<TeamManagerDbContext> options) : base(options)
        {
        }


        public DbSet<Team> Teams { get; set; }
    }
}

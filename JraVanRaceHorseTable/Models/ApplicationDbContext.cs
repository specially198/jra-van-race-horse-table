using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace JraVanRaceHorseTable.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceUma> RaceUmas { get; set; }
        public DbSet<Uma> Umas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    }
}

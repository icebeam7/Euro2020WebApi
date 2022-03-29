using Euro2020WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Euro2020WebApi.Context
{
    public class Euro2020Context : DbContext
    {
        public Euro2020Context(DbContextOptions<Euro2020Context> options) : base(options)
        {

        }

        public DbSet<EuroCity> Cities { get; set; }
        public DbSet<EuroCoach> Coaches { get; set; }
        public DbSet<EuroCountry> Countries { get; set; }
        public DbSet<EuroGroup> Groups { get; set; }
        public DbSet<EuroMatch> Matches { get; set; }
        public DbSet<EuroPlayer> Players { get; set; }
        public DbSet<EuroPosition> Positions { get; set; }
        public DbSet<EuroReferee> Referees { get; set; }
        public DbSet<EuroStadium> Stadiums { get; set; }
        public DbSet<EuroTeam> Teams { get; set; }
    }
}

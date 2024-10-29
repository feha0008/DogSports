using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
namespace DogSports.Models
{
	public class DogSportContext: DbContext
	{
        public DbSet<DogSport>? DogSports { get; set; }

     

        public DogSportContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=dogSports.db");
        }

    }
}


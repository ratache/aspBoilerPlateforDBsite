using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace aspWebProj7.Models
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext() : base("DefaultConnection") { }

        static MovieDbContext()
        {
            Database.SetInitializer<MovieDbContext>
                (new MigrateDatabaseToLatestVersion<MovieDbContext, 
                    Migrations.Configuration>());
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PLTheater.Models
{
    public class DatabaseContex:DbContext
    {

        public DatabaseContex():base("name=DBPlTheatre")
        {
            
        }


        public DbSet<Country> Countries { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Casting> Castings { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Hall> Halls { get; set; }

        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Poster> Posters { get; set; }
        public DbSet<CinemaCasting> CinemaCastings { get; set; }

        public DbSet<ShowTime> ShowTimes { get; set; }

    }
}
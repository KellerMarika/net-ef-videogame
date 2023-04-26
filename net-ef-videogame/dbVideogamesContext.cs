using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    internal class dbVideogamesContext : DbContext
    {
        public DbSet<Videogame> Videogames { get; set; }
        public DbSet<SoftwareHouse> SoftwareHouses { get; set; }
      //  public string connectionString = " Data Source = localhost; Initial Catalog = db_MAGIC_videogames; Integrated Security = True;TrustServerCertificate=True";

        public string connectionString = "Data Source = localhost; Initial Catalog = My_db_videogames; Integrated Security = True;TrustServerCertificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=> optionsBuilder.UseSqlServer(connectionString).LogTo(s => Debug.WriteLine(s));
    }
}

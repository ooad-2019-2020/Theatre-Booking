using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheatreBooking.Models
{
    public class BiloStaContext : DbContext
    {
        public BiloStaContext(DbContextOptions<BiloStaContext> options) : base(options)
        {
        }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<KorisnikUloga> KorisnikUloga { get; set; }
        public DbSet<Predstava> Predstava { get; set; }
        public DbSet<Dogadjaj> Dogadjaj { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<Sjediste> Sjediste { get; set; }

        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            modelBuilder.Entity<KorisnikUloga>().ToTable("KorisnikUloga");
            modelBuilder.Entity<Predstava>().ToTable("Predstava");
            modelBuilder.Entity<Dogadjaj>().ToTable("Dogadjaj");
            modelBuilder.Entity<Sjediste>().ToTable("Sjediste");
            modelBuilder.Entity<Rezervacija>().ToTable("Rezervacija");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1
{
    public partial class BiloSTaContext : DbContext
    {
        public BiloSTaContext()
        {
        }

        public BiloSTaContext(DbContextOptions<BiloSTaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Cuvar> Cuvar { get; set; }
        public virtual DbSet<Dogadjaj> Dogadjaj { get; set; }
        public virtual DbSet<Obavijesti> Obavijesti { get; set; }
        public virtual DbSet<Poruke> Poruke { get; set; }
        public virtual DbSet<Predstava> Predstava { get; set; }
        public virtual DbSet<Prekrsaj> Prekrsaj { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }
        public virtual DbSet<Sektor> Sektor { get; set; }
        public virtual DbSet<Sjediste> Sjediste { get; set; }
        public virtual DbSet<Zatvorenik> Zatvorenik { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:ooad2020new.database.windows.net,1433;Initial Catalog=BiloSTa;Persist Security Info=False;User ID=BiloSta;Password=Test123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Dogadjaj>(entity =>
            {
                entity.Property(e => e.DogadjajId).HasColumnName("DogadjajID");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");

                entity.Property(e => e.Naziv).IsRequired();
            });

            modelBuilder.Entity<Obavijesti>(entity =>
            {
                entity.HasIndex(e => e.ObavijestId);

                entity.HasOne(d => d.Obavijest)
                    .WithMany(p => p.InverseObavijest)
                    .HasForeignKey(d => d.ObavijestId);
            });

            modelBuilder.Entity<Poruke>(entity =>
            {
                entity.HasIndex(e => e.PorukaId);

                entity.Property(e => e.PosiljalacEmail).HasColumnName("posiljalacEmail");

                entity.HasOne(d => d.Poruka)
                    .WithMany(p => p.InversePoruka)
                    .HasForeignKey(d => d.PorukaId);
            });

            modelBuilder.Entity<Predstava>(entity =>
            {
                entity.HasIndex(e => e.DogadjajId);

                entity.Property(e => e.PredstavaId).HasColumnName("PredstavaID");

                entity.Property(e => e.DogadjajId).HasColumnName("DogadjajID");

                entity.HasOne(d => d.Dogadjaj)
                    .WithMany(p => p.Predstava)
                    .HasForeignKey(d => d.DogadjajId);
            });

            modelBuilder.Entity<Prekrsaj>(entity =>
            {
                entity.HasIndex(e => e.ZatvorenikId);

                entity.HasOne(d => d.Zatvorenik)
                    .WithMany(p => p.Prekrsaj)
                    .HasForeignKey(d => d.ZatvorenikId);
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.HasIndex(e => e.PredstavaId);

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.Property(e => e.PredstavaId).HasColumnName("PredstavaID");

                entity.HasOne(d => d.Predstava)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.PredstavaId);
            });

            modelBuilder.Entity<Sektor>(entity =>
            {
                entity.HasIndex(e => e.NadlezniCuvarId);

                entity.HasOne(d => d.NadlezniCuvar)
                    .WithMany(p => p.Sektor)
                    .HasForeignKey(d => d.NadlezniCuvarId);
            });

            modelBuilder.Entity<Sjediste>(entity =>
            {
                entity.HasIndex(e => e.PredstavaId);

                entity.HasIndex(e => e.RezervacijaId);

                entity.Property(e => e.SjedisteId).HasColumnName("SjedisteID");

                entity.Property(e => e.PredstavaId).HasColumnName("PredstavaID");

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.HasOne(d => d.Predstava)
                    .WithMany(p => p.Sjediste)
                    .HasForeignKey(d => d.PredstavaId);

                entity.HasOne(d => d.Rezervacija)
                    .WithMany(p => p.Sjediste)
                    .HasForeignKey(d => d.RezervacijaId);
            });

            modelBuilder.Entity<Zatvorenik>(entity =>
            {
                entity.HasIndex(e => e.SektorId);

                entity.Property(e => e.SektorId).HasColumnName("sektorId");

                entity.HasOne(d => d.Sektor)
                    .WithMany(p => p.Zatvorenik)
                    .HasForeignKey(d => d.SektorId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

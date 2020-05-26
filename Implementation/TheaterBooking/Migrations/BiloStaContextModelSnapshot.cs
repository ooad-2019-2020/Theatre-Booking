﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheatreBooking.Models;

namespace TheaterBooking.Migrations
{
    [DbContext(typeof(BiloStaContext))]
    partial class BiloStaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheatreBooking.Models.Dogadjaj", b =>
                {
                    b.Property<int>("DogadjajID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DogadjajID");

                    b.ToTable("Dogadjaj");
                });

            modelBuilder.Entity("TheatreBooking.Models.Korisnik", b =>
                {
                    b.Property<int>("KorisnikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnikUlogaID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KorisnikID");

                    b.HasIndex("KorisnikUlogaID")
                        .IsUnique();

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("TheatreBooking.Models.KorisnikUloga", b =>
                {
                    b.Property<int>("KorisnikUlogaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojKartice")
                        .HasColumnType("int");

                    b.Property<int>("TipKorisnika")
                        .HasColumnType("int");

                    b.Property<int>("VrstaKartice")
                        .HasColumnType("int");

                    b.HasKey("KorisnikUlogaID");

                    b.ToTable("KorisnikUloga");
                });

            modelBuilder.Entity("TheatreBooking.Models.Predstava", b =>
                {
                    b.Property<int>("PredstavaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DogadjajID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Termin")
                        .HasColumnType("datetime2");

                    b.HasKey("PredstavaID");

                    b.HasIndex("DogadjajID");

                    b.ToTable("Predstava");
                });

            modelBuilder.Entity("TheatreBooking.Models.Rezervacija", b =>
                {
                    b.Property<int>("RezervacijaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("PredstavaID")
                        .HasColumnType("int");

                    b.HasKey("RezervacijaID");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("PredstavaID");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("TheatreBooking.Models.Sjediste", b =>
                {
                    b.Property<int>("SjedisteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojSjedista")
                        .HasColumnType("int");

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<int?>("PredstavaID")
                        .HasColumnType("int");

                    b.Property<int>("RezervacijaID")
                        .HasColumnType("int");

                    b.Property<bool>("Slobodno")
                        .HasColumnType("bit");

                    b.HasKey("SjedisteID");

                    b.HasIndex("PredstavaID");

                    b.HasIndex("RezervacijaID");

                    b.ToTable("Sjediste");
                });

            modelBuilder.Entity("TheatreBooking.Models.Korisnik", b =>
                {
                    b.HasOne("TheatreBooking.Models.KorisnikUloga", "KorisnikUloga")
                        .WithOne("Korisnik")
                        .HasForeignKey("TheatreBooking.Models.Korisnik", "KorisnikUlogaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheatreBooking.Models.Predstava", b =>
                {
                    b.HasOne("TheatreBooking.Models.Dogadjaj", "Dogadjaj")
                        .WithMany("Predstava")
                        .HasForeignKey("DogadjajID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheatreBooking.Models.Rezervacija", b =>
                {
                    b.HasOne("TheatreBooking.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheatreBooking.Models.Predstava", "Predstava")
                        .WithMany("Rezervacija")
                        .HasForeignKey("PredstavaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheatreBooking.Models.Sjediste", b =>
                {
                    b.HasOne("TheatreBooking.Models.Predstava", null)
                        .WithMany("Sjediste")
                        .HasForeignKey("PredstavaID");

                    b.HasOne("TheatreBooking.Models.Rezervacija", "Rezervacija")
                        .WithMany()
                        .HasForeignKey("RezervacijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

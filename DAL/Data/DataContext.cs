using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Artikel> Artikels { get; set; }
        public DbSet<Batterij> Batterijen { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<GebruikerType> GebruikerTypes { get; set; }
        public DbSet<Gemeente> Gemeentes { get; set; }
        public DbSet<Installatie> Installaties { get; set; }
        public DbSet<InstallatieType> InstallatieTypes { get; set; }
        public DbSet<Land> Landen { get; set; }
        public DbSet<Leveradres> Leveradressen { get; set; }
        public DbSet<ModDatum> ModData { get; set; }
        public DbSet<Opmerking> Opmerkingen { get; set; }
        public DbSet<Relatie> Relaties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artikel>().ToTable("Artikel");
            modelBuilder.Entity<Batterij>().ToTable("Batterij");
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruiker");
            modelBuilder.Entity<GebruikerType>().ToTable("GebruikerType");
            modelBuilder.Entity<Gemeente>().ToTable("Gemeente");
            modelBuilder.Entity<Installatie>().ToTable("Installatie");
            modelBuilder.Entity<InstallatieType>().ToTable("InstallatieType");
            modelBuilder.Entity<Land>().ToTable("Land");
            modelBuilder.Entity<Leveradres>().ToTable("Leveradres");
            modelBuilder.Entity<ModDatum>().ToTable("ModDatum");
            modelBuilder.Entity<Opmerking>().ToTable("Opmerking");
            modelBuilder.Entity<Relatie>().ToTable("Relatie");

            foreach (var foreignkey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignkey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}

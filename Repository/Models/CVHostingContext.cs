﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using Repository.IRepo;

namespace Repository.Models
{
    public class CVHostingContext : IdentityDbContext, ICVHostingContext
    {
        public CVHostingContext()
            : base("DefaultConnection")
        {
        }

        public static CVHostingContext Create()
        {
            return new CVHostingContext();
        }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<CVApplication> CVApplication { get; set; }
        public DbSet<CVFile> CVFile { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Potrzebne dla klas Identity
            base.OnModelCreating(modelBuilder);

            // using System.Data.Entity.ModelConfiguration.Conventions;
            //Wyłącza konwencję, która automatycznie tworzy liczbę mnogą dla nazw tabel w bazie danych
            // Zamiast Kategorie zostałaby stworzona tabela o nazwie Kategories
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Wyłącza konwencję CascadeDelete
            // CascadeDelete zostanie włączone za pomocą Fluent API
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Używa się Fluent API, aby ustalić powiązanie pomiędzy tabelami 
            // i włączyć CascadeDelete dla tego powiązania
            //modelBuilder.Entity<Ogloszenie>().HasRequired(x => x.Uzytkownik)
            //    .WithMany(x => x.Ogloszenia)
            //    .HasForeignKey(x => x.UzytkownikId)
            //    .WillCascadeOnDelete(true);
        }
    }
}
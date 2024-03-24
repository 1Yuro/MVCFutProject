using Hafta10.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hafta10.Web.Data
{
    public class DataContext:DbContext
    {
        public  DbSet<KayitModel> kullanicilar { get; set; }
        public DbSet<SkorModel> skorlar { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=EMIN;Database=Futterbet;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KayitModel>().ToTable("kullanicilar");
            modelBuilder.Entity<KayitModel>().HasKey(a=>a.ID);
            modelBuilder.Entity<KayitModel>().Property(a => a.KullaniciAdi).HasMaxLength(50).IsRequired(true);
            modelBuilder.Entity<KayitModel>().Property(a => a.KullaniciSoyadi).HasMaxLength(50).IsRequired(true);
            modelBuilder.Entity<KayitModel>().Property(a => a.KullaniciEmail).HasMaxLength(50).IsRequired(true);
            modelBuilder.Entity<KayitModel>().Property(a => a.KullaniciYas).HasMaxLength(2).IsRequired(true);
            modelBuilder.Entity<KayitModel>().Property(a => a.KullaniciSifre).HasMaxLength(8).IsRequired(true);
            
            modelBuilder.Entity<SkorModel>().ToTable("SkorTablosu");
            modelBuilder.Entity<SkorModel>().HasKey(a => a.ID);
            modelBuilder.Entity<SkorModel>().Property(a => a.TakimAdi).HasMaxLength(50).IsRequired(true);
            modelBuilder.Entity<SkorModel>().Property(a => a.TakimSkoru).IsRequired(true);
            base.OnModelCreating(modelBuilder);
        }

    }
}

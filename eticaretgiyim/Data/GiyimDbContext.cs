using eticaretgiyim.Models;
using Microsoft.EntityFrameworkCore;

namespace eticaretgiyim.Data
{
    public class GiyimDbContext:DbContext
    {
        public GiyimDbContext(DbContextOptions<GiyimDbContext> options):base(options)
        { }
        public DbSet<Kullanicilar> ? kullanicilars { get; set; }
        public DbSet<Kategoriler>? kategorilers { get; set; }
        public DbSet<Urunler>? urunlers { get; set; }
        public DbSet<UrunYildiz>? urunYildizs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategoriler>()
                .HasMany(k => k.Urunlers)
                .WithOne(u => u.Kategoriler)
                .HasForeignKey(u => u.KategoriID);
        }
    }
}

using eticaretgiyim.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eticaretgiyim.Data
{
    public class GiyimDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public GiyimDbContext(DbContextOptions<GiyimDbContext> options):base(options)
        { }
        public DbSet<Kullanicilar> ? kullanicilars { get; set; }
        public DbSet<Kategoriler>? kategorilers { get; set; }
        public DbSet<Urunler>? urunlers { get; set; }
        public DbSet<UrunYildiz>? urunYildizs { get; set; }
        public DbSet<Comments>? comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kategoriler>()
                .HasMany(k => k.Urunlers)
                .WithOne(u => u.Kategoriler)
                .HasForeignKey(u => u.KategoriID);

            modelBuilder.Entity<Urunler>()
                 .HasMany(u => u.Comments)
                 .WithOne(c => c.urunler)
                 .HasForeignKey(c => c.UrunId);
        }
    }
}

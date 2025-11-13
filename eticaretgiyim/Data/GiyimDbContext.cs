using eticaretgiyim.Models;
using Microsoft.EntityFrameworkCore;

namespace eticaretgiyim.Data
{
    public class GiyimDbContext:DbContext
    {
        public GiyimDbContext(DbContextOptions<GiyimDbContext> options):base(options)
        { }
        public DbSet<Kullanicilar>? Kullanicilars { get; set; }
    }
}

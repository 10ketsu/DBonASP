using Bober.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Bober
{
    public class BogbanContext : DbContext
    {
        public BogbanContext(DbContextOptions<BogbanContext> options) : base(options) { }

        public DbSet<District> District { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Dogovor> Dogovor { get; set; }
        public DbSet<Flat> Flat { get; set; }
        public DbSet<Sotrudnik> Sotrudnik { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Zastr> Zastr { get; set; }
        public DbSet<Building> Building { get; set; }

        public BogbanContext() => Database.EnsureCreated();
    }
}

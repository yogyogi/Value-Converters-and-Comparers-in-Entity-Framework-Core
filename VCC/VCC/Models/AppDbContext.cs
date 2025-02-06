using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace VCC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Marketing> Marketing { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .Property(e => e.Tags)
                        .HasConversion(
                            v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                            v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null),
                            new ValueComparer<ICollection<string>>(
                                (c1, c2) => c1.SequenceEqual(c2),
                                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                                c => (ICollection<string>)c.ToList()));

            modelBuilder.Entity<Marketing>()
                        .Property(e => e.Type)
                        .HasConversion(
                            v => v.ToString(),
                            v => (MarketingType)Enum.Parse(typeof(MarketingType), v));

            modelBuilder.Entity<Student>()
                        .Property(e => e.PassStatus)
                        .HasConversion<string>();

            modelBuilder.Entity<Order>()
                        .Property(a => a.Price)
                        .HasConversion(
                            b => JsonSerializer.Serialize(b, (JsonSerializerOptions)null),
                            b => JsonSerializer.Deserialize<Money>(b, (JsonSerializerOptions)null));
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Project.Models;
public partial class DatabaseContext : DbContext
{
    public virtual DbSet<Customer> customers { get; set; } = null!;
    public virtual DbSet<Property> Properties { get; set; } = null!;
    public DatabaseContext()
    {

    }
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasKey(c => c.PhoneNumber);
        modelBuilder.Entity<Customer>().Property(p => p.Name).IsRequired();
        modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.HasIndex(p => p.Category).IsUnique();
            entity.Property(p => p.Category).IsRequired();
            entity.Property(p => p.Price).IsRequired();
        });
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
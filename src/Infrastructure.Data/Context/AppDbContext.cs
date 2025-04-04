using FioTec.Service.Domain.Reports.Entities;
using FioTec.Service.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Report> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.CPF)
            .IsUnique();

        modelBuilder.Entity<Report>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reports)
            .HasForeignKey(r => r.UserId);
    }
}

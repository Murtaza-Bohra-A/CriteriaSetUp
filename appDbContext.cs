using Microsoft.EntityFrameworkCore;
using CriteriaSetUp_BE.Models;

public class appDbContext : DbContext
    {
    public appDbContext(DbContextOptions<appDbContext> options) : base(options)
    {
    }
    public DbSet<CriteriaModule> CriteriaModule { get; set; }
    public DbSet<CriteriaStatus> CriteriaStatus { get; set; }
    public DbSet<CriteriaStatuses> CriteriaStatuses { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CriteriaModule>().ToTable("CriteriaModule");
        modelBuilder.Entity<CriteriaStatus>().ToTable("CriteriaStatus");
        modelBuilder.Entity<CriteriaStatuses>().ToTable("CriteriaStatuses");
    }
}


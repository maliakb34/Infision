
using Infision.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EF;

public partial class DBContext : DbContext
{
  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {


        optionsBuilder.UseNpgsql(Infision.Configure.RootSetting.Roots.AppSettings.DBSqlConnection);


    }
    public DbSet<Brand> Devices => Set<Brand>();
    public DbSet<Product> Product => Set<Product>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Brand>(e =>
        {
            e.ToTable("Brand", "public");    
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(200);
        });
    }
}

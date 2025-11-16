using System;
using System.Collections.Generic;
using Infision.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Infision.Data;

public partial class InfisionDbContext : DbContext
{
    public InfisionDbContext()
    {
    }

    public InfisionDbContext(DbContextOptions<InfisionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=infisiondb;Username=appuser;Password=app123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.id).HasName("departments_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("nextval('departments_id_seq'::regclass)");
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.id).HasName("hospital_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("nextval('hospital_id_seq'::regclass)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.id).HasName("User_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

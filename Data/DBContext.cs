

using Infision.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Infision;

public partial class DBContext : InfisionDbContext
{
  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {


        optionsBuilder.UseNpgsql(Infision.Configure.RootSetting.Roots.AppSettings.DBSqlConnection);


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

     
    }
}

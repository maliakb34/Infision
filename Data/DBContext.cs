

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

     
    }
}

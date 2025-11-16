using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infision.Data.Models;

public partial class Department
{
    [Key]
    public int id { get; set; }

    [StringLength(250)]
    public string? name { get; set; }

    [StringLength(250)]
    public string? title { get; set; }

    public int? status { get; set; }

    [StringLength(50)]
    public string? phone { get; set; }

    [StringLength(350)]
    public string? email { get; set; }
}

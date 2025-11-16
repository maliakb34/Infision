using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infision.Data.Models;

[Table("User")]
public partial class User
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    public string? name { get; set; }

    [StringLength(50)]
    public string? surname { get; set; }

    [StringLength(50)]
    public string? workphone { get; set; }

    [StringLength(250)]
    public string? email { get; set; }

    [StringLength(250)]
    public string? username { get; set; }

    [StringLength(50)]
    public string? password { get; set; }

    public Guid? guid { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? workbegindate { get; set; }

    public int? roleid { get; set; }

    public int? hospitalid { get; set; }

    public int? departmentid { get; set; }

    public int? status { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? logindate { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? lastsessiondate { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? logoutdate { get; set; }

    public int? pushclientid { get; set; }
}

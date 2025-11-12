using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infision.Data.Models;

public partial class User
{
    [Key]
    public long Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? CreateDate { get; set; }

    public short? RoleId { get; set; }

    public string? Phone { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infision.Data.Models;

[Table("Hospital")]
public partial class Hospital
{
    [Key]
    public short Id { get; set; }

    public string? Name { get; set; }

    public string? DeviceId { get; set; }
}

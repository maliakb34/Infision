using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infision.Data.Models;
[Table("Devices")]
public partial class Device
{
    [Key]
    public int Id { get; set; }


    public string Model { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string DeviceType { get; set; } = null!;


    public string SerialNumber { get; set; } = null!;


    public string BootVersion { get; set; } = null!;


    public string ProtocolVersion { get; set; } = null!;

    [StringLength(3)]
    public string Protocol { get; set; } = null!;

    public bool Status { get; set; }
}

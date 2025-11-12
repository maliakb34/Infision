using System;
using System.Collections.Generic;

namespace Infision.Data.Models;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ParentName { get; set; }

    public int? ParentId { get; set; }

    public bool? IsSelectable { get; set; }

    public byte? VendorType { get; set; }

    public byte Status { get; set; }
}

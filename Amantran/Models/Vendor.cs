using System;
using System.Collections.Generic;

namespace Amantran.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string VendorName { get; set; } = null!;

    public string? Phone { get; set; }

    public bool? HasLaptop { get; set; }

    public string? Email { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? VillageId { get; set; }

    public string? VendorType { get; set; }

    public virtual ICollection<Function> Functions { get; set; } = new List<Function>();

    public virtual ICollection<SampleCard> SampleCards { get; set; } = new List<SampleCard>();

    public virtual ICollection<SampleVideo> SampleVideos { get; set; } = new List<SampleVideo>();

    public virtual Village? Village { get; set; }
}

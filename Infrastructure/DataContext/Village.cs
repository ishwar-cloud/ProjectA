using System;
using System.Collections.Generic;

namespace Infrastructure.DataContext;

public partial class Village
{
    public int VillageId { get; set; }

    public int SubDistrictId { get; set; }

    public string VillageName { get; set; } = null!;

    public string VillageCode { get; set; } = null!;

    public string? PinCode { get; set; }

    public virtual ICollection<Function> Functions { get; set; } = new List<Function>();

    public virtual ICollection<Recipient> Recipients { get; set; } = new List<Recipient>();

    public virtual SubDistrict SubDistrict { get; set; } = null!;

    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}

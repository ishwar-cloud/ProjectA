using System;
using System.Collections.Generic;

namespace Infrastructure.DataContext;

public partial class SubDistrict
{
    public int SubDistrictId { get; set; }

    public int DistrictId { get; set; }

    public string SubDistrictCode { get; set; } = null!;

    public string SubDistrictName { get; set; } = null!;

    public virtual District District { get; set; } = null!;

    public virtual ICollection<Village> Villages { get; set; } = new List<Village>();
}

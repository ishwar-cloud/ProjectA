using System;
using System.Collections.Generic;

namespace Amantran.Models;

public partial class District
{
    public int DistrictId { get; set; }

    public int StateId { get; set; }

    public string DistrictCode { get; set; } = null!;

    public string DistrictName { get; set; } = null!;

    public virtual State State { get; set; } = null!;

    public virtual ICollection<SubDistrict> SubDistricts { get; set; } = new List<SubDistrict>();
}

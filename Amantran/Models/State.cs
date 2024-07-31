using System;
using System.Collections.Generic;

namespace Amantran.Models;

public partial class State
{
    public int StateId { get; set; }

    public int CountryId { get; set; }

    public string StateCode { get; set; } = null!;

    public string StateName { get; set; } = null!;

    public virtual ICollection<District> Districts { get; set; } = new List<District>();
}

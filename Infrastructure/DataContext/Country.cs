﻿using System;
using System.Collections.Generic;

namespace Infrastructure.DataContext;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryCode { get; set; } = null!;

    public string CountryName { get; set; } = null!;
}

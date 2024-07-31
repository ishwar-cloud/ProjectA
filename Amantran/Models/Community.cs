﻿using System;
using System.Collections.Generic;

namespace Amantran.Models;

public partial class Community
{
    public int CommunityId { get; set; }

    public string? CommunityName { get; set; }

    public virtual ICollection<Recipient> Recipients { get; set; } = new List<Recipient>();
}

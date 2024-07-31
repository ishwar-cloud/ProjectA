using System;
using System.Collections.Generic;

namespace Amantran.Models;

public partial class InvitedBy
{
    public int InvitedById { get; set; }

    public string InvitedByName { get; set; } = null!;

    public string? Relation { get; set; }

    public int FunctionId { get; set; }

    public bool Default { get; set; }

    public  Function Function { get; set; } = null!;


    public virtual ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();

    
    
}

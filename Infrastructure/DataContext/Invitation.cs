using System;
using System.Collections.Generic;

namespace Infrastructure.DataContext;

public partial class Invitation
{
    public int InvitationId { get; set; }

    public int? RecipientId { get; set; }

    public int? FunctionId { get; set; }

    public int? InvitedById { get; set; }

    public string? Status { get; set; }

    public string? Language { get; set; }

    public bool? Individual { get; set; }

    public bool? WholeFamily { get; set; }

    public bool? Favourite { get; set; }

    public bool? Wedding { get; set; }

    public bool? Halad { get; set; }

    public bool? Gaval { get; set; }

    public bool? Ovalane { get; set; }

    public bool? Reception { get; set; }

    public bool? Sangeet { get; set; }

    public bool? Mehendi { get; set; }

    public bool? VaidikVivah { get; set; }

    public string? FunctionDetailsFinalW { get; set; }

    public string? InvitedByW { get; set; }

    public string? InvitedForW { get; set; }

    public string? NimantrakW { get; set; }

    public string? RecipientWhatsappNumber { get; set; }

    public string? RecipientW { get; set; }

    public virtual Function? Function { get; set; }

    public virtual InvitedBy? InvitedBy { get; set; }

    public virtual Recipient? Recipient { get; set; }

    public virtual ICollection<WhatsappMessage> WhatsappMessages { get; set; } = new List<WhatsappMessage>();
}

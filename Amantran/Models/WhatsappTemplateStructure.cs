using System;
using System.Collections.Generic;

namespace Amantran.Models;

public partial class WhatsappTemplateStructure
{
    public int TemplateStructureId { get; set; }

    public bool? IsDefault { get; set; }

    public string? DocumentFileName { get; set; }

    public string? FooterText { get; set; }

    public int? FunctionId { get; set; }

    public string? HeaderText { get; set; }

    public string? Language { get; set; }

    public string? LocationAddress { get; set; }

    public string? LocationLatitude { get; set; }

    public string? LocationLongitude { get; set; }

    public string? LocationName { get; set; }

    public string? MediaCaption { get; set; }

    public string? MediaId { get; set; }

    public string? MediaLink { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public int? CardId { get; set; }

    public int? SampleVideoId { get; set; }

    public int? SequenceNumber { get; set; }

    public int? TemplateId { get; set; }

    public virtual SampleCard? Card { get; set; }

    public virtual Function? Function { get; set; }

    public virtual SampleVideo? SampleVideo { get; set; }

    public virtual WhatsappTemplate? Template { get; set; }

    public virtual ICollection<WhatsappMessage> WhatsappMessages { get; set; } = new List<WhatsappMessage>();
}

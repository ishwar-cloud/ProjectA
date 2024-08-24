using System;
using System.Collections.Generic;

namespace Infrastructure.DataContext;

public partial class SampleCard
{
    public int CardId { get; set; }

    public string? Colour { get; set; }

    public string? FunctionType { get; set; }

    public string? Language { get; set; }

    public string? SampleCardName { get; set; }

    public string? Theme { get; set; }

    public int? CardDesignerId { get; set; }

    public virtual Vendor? CardDesigner { get; set; }

    public virtual ICollection<WhatsappTemplateStructure> WhatsappTemplateStructures { get; set; } = new List<WhatsappTemplateStructure>();
}

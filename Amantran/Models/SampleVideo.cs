using System;
using System.Collections.Generic;

namespace Amantran.Models;

public partial class SampleVideo
{
    public int SampleVideoId { get; set; }

    public decimal? DurationSec { get; set; }

    public string? FunctionType { get; set; }

    public string? Language { get; set; }

    public string? Relation { get; set; }

    public string? SampleVideoName { get; set; }

    public int? VideoCreatorId { get; set; }

    public virtual Vendor? VideoCreator { get; set; }

    public virtual ICollection<WhatsappTemplateStructure> WhatsappTemplateStructures { get; set; } = new List<WhatsappTemplateStructure>();
}

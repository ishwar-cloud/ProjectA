using System;
using System.Collections.Generic;

namespace Infrastructure.DataContext;

public partial class WhatsappTemplate
{
    public int TemplateId { get; set; }

    public string? Category { get; set; }

    public string? HeaderType { get; set; }

    public string? InvitationType { get; set; }

    public string? Language { get; set; }

    public string? LanguageCode { get; set; }

    public string? MediaType { get; set; }

    public string? TemplateName { get; set; }

    public int? VariableCount { get; set; }

    public string? VariableSequence { get; set; }

    public virtual ICollection<WhatsappTemplateStructure> WhatsappTemplateStructures { get; set; } = new List<WhatsappTemplateStructure>();
}

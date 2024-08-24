using System;
using System.Collections.Generic;

namespace Infrastructure.DataContext;

public partial class WhatsappMessage
{
    public int MessageId { get; set; }

    public DateTime? AcceptedDatetime { get; set; }

    public DateTime? ApiErrorDatetime { get; set; }

    public string? ApiErrorMessage { get; set; }

    public DateTime? DeletedDatetime { get; set; }

    public DateTime? DeliveredDatetime { get; set; }

    public DateTime? FailedDatetime { get; set; }

    public string? FinalStatus { get; set; }

    public string? FunctionIdText { get; set; }

    public int? InvitationId { get; set; }

    public string? InvitationType { get; set; }

    public string? LanguageCode { get; set; }

    public string? MediaType { get; set; }

    public DateTime? ReadDatetime { get; set; }

    public string? RecipientWhatsappNumber { get; set; }

    public DateTime? SentDatetime { get; set; }

    public int? SequenceNumber { get; set; }

    public string? Status { get; set; }

    public string? VariableSequence { get; set; }

    public int? TemplateStructureId { get; set; }

    public string? WhatsaapTemplateName { get; set; }

    public virtual Invitation? Invitation { get; set; }

    public virtual WhatsappTemplateStructure? TemplateStructure { get; set; }
}

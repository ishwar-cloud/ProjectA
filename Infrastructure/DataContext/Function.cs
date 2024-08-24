using System;
using System.Collections.Generic;

namespace Infrastructure.DataContext;

public partial class Function
{
    public int FunctionId { get; set; }

    public string? FunctionType { get; set; }

    public string? FunctionName { get; set; }

    public string? FunctionFor { get; set; }

    public string? FunctionDay { get; set; }

    public DateTime? FunctionDateTime { get; set; }

    public string? FunctionStage { get; set; }

    public string? FunctionLocationPinW { get; set; }

    public bool? IsSangit { get; set; }

    public DateTime? SangeetDateTime { get; set; }

    public string? SangeetDetailsW { get; set; }

    public string? SangeetDay { get; set; }

    public string? SangeetLocation { get; set; }

    public string? SangeetLocationPinW { get; set; }

    public bool? IsMehandi { get; set; }

    public DateTime? MehandiDateTime { get; set; }

    public string? MehandiDetailsW { get; set; }

    public string? MehandiDay { get; set; }

    public string? MehandiLocation { get; set; }

    public string? MehandiLocationPinW { get; set; }

    public bool? IsGaval { get; set; }

    public DateTime? GavalDateTime { get; set; }

    public string? GavalDetailsW { get; set; }

    public string? GavalDay { get; set; }

    public string? GavalLocation { get; set; }

    public string? GavalLocationPinW { get; set; }

    public bool? IsHalad { get; set; }

    public DateTime? HaladDateTime { get; set; }

    public string? HaladDetailsW { get; set; }

    public string? HaladDay { get; set; }

    public string? HaladLocation { get; set; }

    public string? HaladLocationPinW { get; set; }

    public bool? IsWeeding { get; set; }

    public DateTime? WeddingDateTime { get; set; }

    public string? WeddingDetailsW { get; set; }

    public string? WeddingDay { get; set; }

    public string? WeddingLocation { get; set; }

    public string? WeddingLocationPinW { get; set; }

    public bool? IsVaidikVivah { get; set; }

    public DateTime? VaidikVivahDateTime { get; set; }

    public string? VaidikVivahDetailsW { get; set; }

    public string? VaidikVivahDay { get; set; }

    public string? VaidikVivahLocation { get; set; }

    public string? VaidikVivahLocationPinW { get; set; }

    public bool? IsJanavsa { get; set; }

    public string? JanavsaDetailsW { get; set; }

    public string? JanavsaDay { get; set; }

    public string? JanavsaLocation { get; set; }

    public string? JanavsaLocationPinW { get; set; }

    public bool? IsOvalane { get; set; }

    public DateTime? OvalaneDateTime { get; set; }

    public string? OvalaneDetailsW { get; set; }

    public string? OvalaneDay { get; set; }

    public string? OvalaneLocation { get; set; }

    public string? OvalneLocationPinW { get; set; }

    public bool? IsReception { get; set; }

    public DateTime? ReceptionDateTime { get; set; }

    public string? ReceptionDetailsW { get; set; }

    public string? ReceptionDay { get; set; }

    public string? ReceptionLocation { get; set; }

    public string? ReceptionLocationPinW { get; set; }

    public bool? IsBirthday { get; set; }

    public int? BirthdayNumber { get; set; }

    public bool? IsPunyasmaran { get; set; }

    public int? PunyasmaranNumber { get; set; }

    public bool? IsKatha { get; set; }

    public DateOnly? KathaEndDate { get; set; }

    public DateOnly? KathaStartDate { get; set; }

    public string? KathaTiming { get; set; }

    public string? Shokakul { get; set; }

    public bool? IsAnniversary { get; set; }

    public int? AnniversaryNumber { get; set; }

    public int? BrideId { get; set; }

    public string? BrideBirthName { get; set; }

    public int? GroomId { get; set; }

    public string? GroomBirthName { get; set; }

    public string? FamilyName { get; set; }

    public string? GrandFather { get; set; }

    public string? GrandMother { get; set; }

    public string? Mother { get; set; }

    public string? Father { get; set; }

    public string? NimantrakGents { get; set; }

    public string? NimantrakLadies { get; set; }

    public string? ChiefGuest { get; set; }

    public int? VillageId { get; set; }

    public string? WholeFamilyTextW { get; set; }

    public int? CardDesignerId { get; set; }

    public int? VideoCreator { get; set; }

    public int? TotalVideos { get; set; }

    public bool? FinalCardsReceived { get; set; }

    public bool? FinalVideosReceived { get; set; }

    public string? MarathiFunctionDetailsW { get; set; }

    public string? MarathiGavalDetailsW { get; set; }

    public string? MarathiHaladDetailsW { get; set; }

    public string? MarathiInvitedForW { get; set; }

    public string? MarathiJanavsaDetailsW { get; set; }

    public string? MarathiMehandiDetailsW { get; set; }

    public string? MarathiNimantrakGents { get; set; }

    public string? MarathiNimantrakLadies { get; set; }

    public string? MarathiOvalneDetailsW { get; set; }

    public string? MarathiReceptionDetailsW { get; set; }

    public string? MarathiSangeetDetailsW { get; set; }

    public string? MarathiVaidikVivahDetailsW { get; set; }

    public string? MarathiWeddingDetailsW { get; set; }

    public string? HindiFunctionDetailsW { get; set; }

    public string? HindiGavalDetailsW { get; set; }

    public string? HindiHaladDetailsW { get; set; }

    public string? HindiInvitedForW { get; set; }

    public string? HindiJanavsaDetailsW { get; set; }

    public string? HindiMehandiDetailsW { get; set; }

    public string? HindiNimantrakGents { get; set; }

    public string? HindiNimantrakLadies { get; set; }

    public string? HindiOvalneDetailsW { get; set; }

    public string? HindiReceptionDetailsW { get; set; }

    public string? HindiSangeetDetailsW { get; set; }

    public string? HindiVaidikVivahDetailsW { get; set; }

    public string? HindiWeddingDetailsW { get; set; }

    public decimal? AdvanceReceivedMoney { get; set; }

    public decimal? Discount { get; set; }

    public bool? ApprovedByClient { get; set; }

    public DateTime? SendInvitationsOn { get; set; }

    public DateTime? SendRemindersOn { get; set; }

    public bool? InvitationsSelected { get; set; }

    public decimal? Tax { get; set; }

    public int? PriceBookId { get; set; }

    public string? PersonName { get; set; }

    public int? PointOfContact { get; set; }

    public DateOnly? ActualDate { get; set; }

    public string? ActualDay { get; set; }

    public string? Variable1 { get; set; }

    public string? Variable2 { get; set; }

    public string? Variable3 { get; set; }

    public string? Variable4 { get; set; }

    public string? Variable5 { get; set; }

    public string? Variable6 { get; set; }

    public string? Variable7 { get; set; }

    public string? Variable8 { get; set; }

    public string? Variable9 { get; set; }

    public string? Variable10 { get; set; }

    public string? InvitedForW { get; set; }

    public virtual Recipient? Bride { get; set; }

    public virtual Vendor? CardDesigner { get; set; }

    public virtual Recipient? Groom { get; set; }

    public virtual ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();

    public virtual ICollection<InvitedBy> InvitedBies { get; set; } = new List<InvitedBy>();

    public virtual Recipient? PointOfContactNavigation { get; set; }

    public virtual PriceBook? PriceBook { get; set; }

    public virtual Village? Village { get; set; }

    public virtual ICollection<WhatsappTemplateStructure> WhatsappTemplateStructures { get; set; } = new List<WhatsappTemplateStructure>();
}

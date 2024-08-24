using System;
using System.Collections.Generic;

namespace Infrastructure.DataContext;

public partial class Recipient
{
    public int RecipientId { get; set; }

    public string? RecipientName { get; set; }

    public string? Salutation { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string? KnownAs { get; set; }

    public string? Gender { get; set; }

    public string? RelationshipStatus { get; set; }

    public int? Age { get; set; }

    public bool? Dead { get; set; }

    public string? Notes { get; set; }

    public int? VillageId { get; set; }

    public bool? AvailableOnWhatsapp { get; set; }

    public string? CountryCode { get; set; }

    public string? WhatsappNumber { get; set; }

    public int? CommunityId { get; set; }

    public string? Email { get; set; }

    public string? Education { get; set; }

    public string? EducationCategory { get; set; }

    public string? Occupation { get; set; }

    public string? OccupationCategory { get; set; }

    public string? Title { get; set; }

    public string? CurrentLocation { get; set; }

    public string? ForeignResidence { get; set; }

    public string? AllMarriedDaughters { get; set; }

    public string? Kul { get; set; }

    public string? Gotra { get; set; }

    public string? DataCollectionId { get; set; }

    public string? FamilyTreeId { get; set; }

    public string? CompleteFamilyId { get; set; }

    public string? BloodGroup { get; set; }

    public int? BloodRequestReceived { get; set; }

    public int? BloodRequestSentCount { get; set; }

    public string? HindiRecipientName { get; set; }

    public string? HindiSalutation { get; set; }

    public string? HindiFirstName { get; set; }

    public string? HindiMiddleName { get; set; }

    public string? HindiLastName { get; set; }

    public string? MarathiRecipientName { get; set; }

    public string? MarathiSalutationDel { get; set; }

    public string? MarathiMiddleName { get; set; }

    public string? MarathiFirstName { get; set; }

    public string? MarathiLastName { get; set; }

    public int? FatherId { get; set; }

    public int? MotherId { get; set; }

    public int? SpouseId { get; set; }

    public virtual Community? Community { get; set; }

    public virtual Recipient? Father { get; set; }

    public virtual ICollection<Function> FunctionBrides { get; set; } = new List<Function>();

    public virtual ICollection<Function> FunctionGrooms { get; set; } = new List<Function>();

    public virtual ICollection<Function> FunctionPointOfContactNavigations { get; set; } = new List<Function>();

    public virtual ICollection<Recipient> InverseFather { get; set; } = new List<Recipient>();

    public virtual ICollection<Recipient> InverseMother { get; set; } = new List<Recipient>();

    public virtual ICollection<Recipient> InverseSpouse { get; set; } = new List<Recipient>();

    public virtual ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();

    public virtual Recipient? Mother { get; set; }

    public virtual Recipient? Spouse { get; set; }

    public virtual Village? Village { get; set; }
}

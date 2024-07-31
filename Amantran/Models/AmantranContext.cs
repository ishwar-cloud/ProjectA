using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Amantran.Models;

public partial class AmantranContext : DbContext
{
    public AmantranContext()
    {
    }

    public AmantranContext(DbContextOptions<AmantranContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Community> Communities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Function> Functions { get; set; }

    public virtual DbSet<Invitation> Invitations { get; set; }

    public virtual DbSet<InvitedBy> InvitedBies { get; set; }

    public virtual DbSet<PriceBook> PriceBooks { get; set; }

    public virtual DbSet<Recipient> Recipients { get; set; }

    public virtual DbSet<SampleCard> SampleCards { get; set; }

    public virtual DbSet<SampleVideo> SampleVideos { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<SubDistrict> SubDistricts { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<Village> Villages { get; set; }

    public virtual DbSet<WhatsappMessage> WhatsappMessages { get; set; }

    public virtual DbSet<WhatsappTemplate> WhatsappTemplates { get; set; }

    public virtual DbSet<WhatsappTemplateStructure> WhatsappTemplateStructures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=connString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Community>(entity =>
        {
            entity.HasKey(e => e.CommunityId).HasName("PK__communit__3A18739FC978F14E");

            entity.ToTable("community");

            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.CommunityName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("community_Name");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__country__7E8CD055ED583D7F");

            entity.ToTable("country");

            entity.HasIndex(e => e.CountryCode, "UQ__country__3436E9A58C093C95").IsUnique();

            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("country_code");
            entity.Property(e => e.CountryName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("country_name");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PK__district__2521322B1E4AD077");

            entity.ToTable("district");

            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.DistrictCode)
                .HasMaxLength(3)
                .HasColumnName("district_code");
            entity.Property(e => e.DistrictName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("district_name");
            entity.Property(e => e.StateId).HasColumnName("state_id");

            entity.HasOne(d => d.State).WithMany(p => p.Districts)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__district__state___5070F446");
        });

        modelBuilder.Entity<Function>(entity =>
        {
            entity.HasKey(e => e.FunctionId).HasName("PK__function__FC85AD04A75B49C2");

            entity.ToTable("function_");

            entity.Property(e => e.FunctionId).HasColumnName("function_id");
            entity.Property(e => e.ActualDate).HasColumnName("Actual_date");
            entity.Property(e => e.ActualDay)
                .HasMaxLength(9)
                .HasColumnName("Actual_day");
            entity.Property(e => e.AdvanceReceivedMoney)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("advance_received_money");
            entity.Property(e => e.AnniversaryNumber).HasColumnName("anniversary_number");
            entity.Property(e => e.ApprovedByClient).HasColumnName("approved_by_client");
            entity.Property(e => e.BirthdayNumber).HasColumnName("birthday_number");
            entity.Property(e => e.BrideBirthName)
                .HasMaxLength(30)
                .HasColumnName("bride_birth_name");
            entity.Property(e => e.BrideId).HasColumnName("bride_id");
            entity.Property(e => e.CardDesignerId).HasColumnName("card_designer_id");
            entity.Property(e => e.ChiefGuest)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("chief_guest");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.FamilyName)
                .HasMaxLength(30)
                .HasColumnName("family_name");
            entity.Property(e => e.Father)
                .HasMaxLength(55)
                .HasColumnName("father");
            entity.Property(e => e.FinalCardsReceived).HasColumnName("final_cards_received");
            entity.Property(e => e.FinalVideosReceived).HasColumnName("final_videos_received");
            entity.Property(e => e.FunctionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("function_date_time");
            entity.Property(e => e.FunctionDay)
                .HasMaxLength(9)
                .HasColumnName("function_day");
            entity.Property(e => e.FunctionFor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("function_for");
            entity.Property(e => e.FunctionLocationPinW)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("function_location_pin_w");
            entity.Property(e => e.FunctionName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("function_name_");
            entity.Property(e => e.FunctionStage)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("function_stage");
            entity.Property(e => e.FunctionType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("function_type");
            entity.Property(e => e.GavalDateTime)
                .HasColumnType("datetime")
                .HasColumnName("gaval_date_time");
            entity.Property(e => e.GavalDay)
                .HasMaxLength(9)
                .HasColumnName("gaval_day");
            entity.Property(e => e.GavalDetailsW)
                .IsUnicode(false)
                .HasColumnName("gaval_details_w");
            entity.Property(e => e.GavalLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("gaval_location");
            entity.Property(e => e.GavalLocationPinW)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("gaval_location_pin_w");
            entity.Property(e => e.GrandFather)
                .HasMaxLength(55)
                .HasColumnName("grand_father");
            entity.Property(e => e.GrandMother)
                .HasMaxLength(55)
                .HasColumnName("grand_mother");
            entity.Property(e => e.GroomBirthName)
                .HasMaxLength(30)
                .HasColumnName("groom_birth_name");
            entity.Property(e => e.GroomId).HasColumnName("groom_id");
            entity.Property(e => e.HaladDateTime)
                .HasColumnType("datetime")
                .HasColumnName("halad_date_time");
            entity.Property(e => e.HaladDay)
                .HasMaxLength(9)
                .HasColumnName("halad_day");
            entity.Property(e => e.HaladDetailsW)
                .IsUnicode(false)
                .HasColumnName("halad_details_w");
            entity.Property(e => e.HaladLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("halad_location");
            entity.Property(e => e.HaladLocationPinW)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("halad_location_pin_w");
            entity.Property(e => e.HindiFunctionDetailsW).HasColumnName("hindi_function_details_w");
            entity.Property(e => e.HindiGavalDetailsW).HasColumnName("hindi_gaval_details_w");
            entity.Property(e => e.HindiHaladDetailsW).HasColumnName("hindi_halad_details_w");
            entity.Property(e => e.HindiInvitedForW).HasColumnName("hindi_invited_for_w");
            entity.Property(e => e.HindiJanavsaDetailsW).HasColumnName("hindi_janavsa_details_w");
            entity.Property(e => e.HindiMehandiDetailsW).HasColumnName("hindi_mehandi_details_w");
            entity.Property(e => e.HindiNimantrakGents).HasColumnName("hindi_nimantrak_gents");
            entity.Property(e => e.HindiNimantrakLadies).HasColumnName("hindi_nimantrak_ladies");
            entity.Property(e => e.HindiOvalneDetailsW).HasColumnName("hindi_ovalne_details_w");
            entity.Property(e => e.HindiReceptionDetailsW).HasColumnName("hindi_reception_details_w");
            entity.Property(e => e.HindiSangeetDetailsW).HasColumnName("hindi_sangeet_details_w");
            entity.Property(e => e.HindiVaidikVivahDetailsW).HasColumnName("hindi_vaidik_vivah_details_w");
            entity.Property(e => e.HindiWeddingDetailsW).HasColumnName("hindi_wedding_details_w");
            entity.Property(e => e.InvitationsSelected).HasColumnName("invitations_selected");
            entity.Property(e => e.IsBirthday).HasColumnName("isBirthday");
            entity.Property(e => e.IsGaval).HasColumnName("isGaval");
            entity.Property(e => e.IsHalad).HasColumnName("isHalad");
            entity.Property(e => e.IsJanavsa).HasColumnName("isJanavsa");
            entity.Property(e => e.IsKatha).HasColumnName("isKatha");
            entity.Property(e => e.IsMehandi).HasColumnName("isMehandi");
            entity.Property(e => e.IsOvalane).HasColumnName("isOvalane");
            entity.Property(e => e.IsPunyasmaran).HasColumnName("isPunyasmaran");
            entity.Property(e => e.IsReception).HasColumnName("isReception");
            entity.Property(e => e.IsVaidikVivah).HasColumnName("isVaidik_Vivah");
            entity.Property(e => e.JanavsaDay)
                .HasMaxLength(9)
                .HasColumnName("Janavsa_day");
            entity.Property(e => e.JanavsaDetailsW)
                .IsUnicode(false)
                .HasColumnName("Janavsa_details_w");
            entity.Property(e => e.JanavsaLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("janavsa_location");
            entity.Property(e => e.JanavsaLocationPinW)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("janavsa_location_pin_w");
            entity.Property(e => e.KathaEndDate).HasColumnName("katha_end_date");
            entity.Property(e => e.KathaStartDate).HasColumnName("katha_start_date");
            entity.Property(e => e.KathaTiming)
                .HasMaxLength(50)
                .HasColumnName("katha_timing");
            entity.Property(e => e.MarathiFunctionDetailsW).HasColumnName("marathi_function_details_w");
            entity.Property(e => e.MarathiGavalDetailsW).HasColumnName("marathi_gaval_details_w");
            entity.Property(e => e.MarathiHaladDetailsW).HasColumnName("marathi_halad_details_w");
            entity.Property(e => e.MarathiInvitedForW).HasColumnName("marathi_invited_for_w");
            entity.Property(e => e.MarathiJanavsaDetailsW).HasColumnName("marathi_janavsa_details_w");
            entity.Property(e => e.MarathiMehandiDetailsW).HasColumnName("marathi_mehandi_details_w");
            entity.Property(e => e.MarathiNimantrakGents).HasColumnName("marathi_nimantrak_gents");
            entity.Property(e => e.MarathiNimantrakLadies).HasColumnName("marathi_nimantrak_ladies");
            entity.Property(e => e.MarathiOvalneDetailsW).HasColumnName("marathi_ovalne_details_w");
            entity.Property(e => e.MarathiReceptionDetailsW).HasColumnName("marathi_reception_details_w");
            entity.Property(e => e.MarathiSangeetDetailsW).HasColumnName("marathi_sangeet_details_w");
            entity.Property(e => e.MarathiVaidikVivahDetailsW).HasColumnName("marathi_vaidik_vivah_details_w");
            entity.Property(e => e.MarathiWeddingDetailsW).HasColumnName("marathi_wedding_details_w");
            entity.Property(e => e.MehandiDateTime)
                .HasColumnType("datetime")
                .HasColumnName("mehandi_date_time");
            entity.Property(e => e.MehandiDay)
                .HasMaxLength(9)
                .HasColumnName("mehandi_day");
            entity.Property(e => e.MehandiDetailsW)
                .IsUnicode(false)
                .HasColumnName("mehandi_details_w");
            entity.Property(e => e.MehandiLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mehandi_location");
            entity.Property(e => e.MehandiLocationPinW)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("mehandi_location_pin_w");
            entity.Property(e => e.Mother)
                .HasMaxLength(55)
                .HasColumnName("mother");
            entity.Property(e => e.NimantrakGents)
                .IsUnicode(false)
                .HasColumnName("nimantrak_gents");
            entity.Property(e => e.NimantrakLadies)
                .IsUnicode(false)
                .HasColumnName("nimantrak_ladies");
            entity.Property(e => e.OvalaneDateTime)
                .HasColumnType("datetime")
                .HasColumnName("ovalane_date_time");
            entity.Property(e => e.OvalaneDay)
                .HasMaxLength(9)
                .HasColumnName("ovalane_day");
            entity.Property(e => e.OvalaneDetailsW)
                .IsUnicode(false)
                .HasColumnName("ovalane_details_w");
            entity.Property(e => e.OvalaneLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ovalane_location");
            entity.Property(e => e.OvalneLocationPinW)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ovalne_location_pin_w");
            entity.Property(e => e.PersonName)
                .HasMaxLength(55)
                .HasColumnName("person_name");
            entity.Property(e => e.PointOfContact).HasColumnName("point_of_contact");
            entity.Property(e => e.PriceBookId).HasColumnName("price_book_id");
            entity.Property(e => e.PunyasmaranNumber).HasColumnName("punyasmaran_number");
            entity.Property(e => e.ReceptionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("reception_date_time");
            entity.Property(e => e.ReceptionDay)
                .HasMaxLength(9)
                .HasColumnName("reception_day");
            entity.Property(e => e.ReceptionDetailsW)
                .IsUnicode(false)
                .HasColumnName("reception_details_w");
            entity.Property(e => e.ReceptionLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("reception_location");
            entity.Property(e => e.ReceptionLocationPinW)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("reception_location_pin_w");
            entity.Property(e => e.SangeetDateTime)
                .HasColumnType("datetime")
                .HasColumnName("sangeet_date_time");
            entity.Property(e => e.SangeetDay)
                .HasMaxLength(9)
                .HasColumnName("sangeet_day");
            entity.Property(e => e.SangeetDetailsW)
                .IsUnicode(false)
                .HasColumnName("sangeet_details_w");
            entity.Property(e => e.SangeetLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sangeet_location");
            entity.Property(e => e.SangeetLocationPinW)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("sangeet_location_pin_w");
            entity.Property(e => e.SendInvitationsOn)
                .HasColumnType("datetime")
                .HasColumnName("send_invitations_on");
            entity.Property(e => e.SendRemindersOn)
                .HasColumnType("datetime")
                .HasColumnName("send_reminders_on");
            entity.Property(e => e.Shokakul)
                .HasMaxLength(255)
                .HasColumnName("shokakul");
            entity.Property(e => e.Tax)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("tax");
            entity.Property(e => e.TotalVideos).HasColumnName("total_videos");
            entity.Property(e => e.VaidikVivahDateTime)
                .HasColumnType("datetime")
                .HasColumnName("vaidik_vivah_date_time");
            entity.Property(e => e.VaidikVivahDay)
                .HasMaxLength(9)
                .HasColumnName("vaidik_vivah_day");
            entity.Property(e => e.VaidikVivahDetailsW)
                .IsUnicode(false)
                .HasColumnName("vaidik_vivah_details_w");
            entity.Property(e => e.VaidikVivahLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("vaidik_vivah_location");
            entity.Property(e => e.VaidikVivahLocationPinW)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("vaidik_vivah_location_pin_w");
            entity.Property(e => e.Variable1)
                .HasMaxLength(1030)
                .HasColumnName("variable1");
            entity.Property(e => e.Variable10)
                .HasMaxLength(1000)
                .HasColumnName("variable10");
            entity.Property(e => e.Variable2)
                .HasMaxLength(1000)
                .HasColumnName("variable2");
            entity.Property(e => e.Variable3)
                .HasMaxLength(1000)
                .HasColumnName("variable3");
            entity.Property(e => e.Variable4)
                .HasMaxLength(1000)
                .HasColumnName("variable4");
            entity.Property(e => e.Variable5)
                .HasMaxLength(1000)
                .HasColumnName("variable5");
            entity.Property(e => e.Variable6)
                .HasMaxLength(1000)
                .HasColumnName("variable6");
            entity.Property(e => e.Variable7)
                .HasMaxLength(1000)
                .HasColumnName("variable7");
            entity.Property(e => e.Variable8)
                .HasMaxLength(1000)
                .HasColumnName("variable8");
            entity.Property(e => e.Variable9)
                .HasMaxLength(1000)
                .HasColumnName("variable9");
            entity.Property(e => e.VideoCreator).HasColumnName("video_creator");
            entity.Property(e => e.VillageId).HasColumnName("village_id");
            entity.Property(e => e.WeddingDateTime)
                .HasColumnType("datetime")
                .HasColumnName("wedding_date_time");
            entity.Property(e => e.WeddingDay)
                .HasMaxLength(9)
                .HasColumnName("wedding_day");
            entity.Property(e => e.WeddingDetailsW)
                .IsUnicode(false)
                .HasColumnName("wedding_details_w");
            entity.Property(e => e.WeddingLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("wedding_location");
            entity.Property(e => e.WeddingLocationPinW)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("wedding_location_pin_w");
            entity.Property(e => e.WholeFamilyTextW)
                .IsUnicode(false)
                .HasColumnName("whole_family_text_w");

            entity.HasOne(d => d.Bride).WithMany(p => p.FunctionBrides)
                .HasForeignKey(d => d.BrideId)
                .HasConstraintName("FK__function___bride__797309D9");

            entity.HasOne(d => d.CardDesigner).WithMany(p => p.Functions)
                .HasForeignKey(d => d.CardDesignerId)
                .HasConstraintName("FK__function___card___7B5B524B");

            entity.HasOne(d => d.Groom).WithMany(p => p.FunctionGrooms)
                .HasForeignKey(d => d.GroomId)
                .HasConstraintName("FK__function___groom__787EE5A0");

            entity.HasOne(d => d.PointOfContactNavigation).WithMany(p => p.FunctionPointOfContactNavigations)
                .HasForeignKey(d => d.PointOfContact)
                .HasConstraintName("FK__function___point__7A672E12");

            entity.HasOne(d => d.PriceBook).WithMany(p => p.Functions)
                .HasForeignKey(d => d.PriceBookId)
                .HasConstraintName("FK__function___price__7D439ABD");

            entity.HasOne(d => d.Village).WithMany(p => p.Functions)
                .HasForeignKey(d => d.VillageId)
                .HasConstraintName("FK__function___villa__7C4F7684");
        });

        modelBuilder.Entity<Invitation>(entity =>
        {
            entity.HasKey(e => e.InvitationId).HasName("PK__invitati__94B74D7C56F92EE2");

            entity.ToTable("invitation");

            entity.Property(e => e.InvitationId).HasColumnName("invitation_id");
            entity.Property(e => e.Favourite).HasColumnName("favourite");
            entity.Property(e => e.FunctionDetailsFinalW).HasColumnName("function_details_final_w");
            entity.Property(e => e.FunctionId).HasColumnName("function_id");
            entity.Property(e => e.Gaval).HasColumnName("gaval");
            entity.Property(e => e.Halad).HasColumnName("halad");
            entity.Property(e => e.Individual).HasColumnName("individual");
            entity.Property(e => e.InvitedById).HasColumnName("invited_by_id");
            entity.Property(e => e.InvitedByW).HasColumnName("invited_by_w");
            entity.Property(e => e.InvitedForW).HasColumnName("invited_for_w");
            entity.Property(e => e.Language)
                .HasMaxLength(255)
                .HasColumnName("language");
            entity.Property(e => e.Mehendi).HasColumnName("mehendi");
            entity.Property(e => e.NimantrakW).HasColumnName("nimantrak_w");
            entity.Property(e => e.Ovalane).HasColumnName("ovalane");
            entity.Property(e => e.Reception).HasColumnName("reception");
            entity.Property(e => e.RecipientId).HasColumnName("recipient_id");
            entity.Property(e => e.RecipientW).HasColumnName("recipient_w");
            entity.Property(e => e.RecipientWhatsappNumber).HasColumnName("recipient_whatsapp_number");
            entity.Property(e => e.Sangeet).HasColumnName("sangeet");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.VaidikVivah).HasColumnName("vaidik_vivah");
            entity.Property(e => e.Wedding).HasColumnName("wedding");
            entity.Property(e => e.WholeFamily).HasColumnName("whole_family");

            entity.HasOne(d => d.Function).WithMany(p => p.Invitations)
                .HasForeignKey(d => d.FunctionId)
                .HasConstraintName("FK__invitatio__funct__02FC7413");

            entity.HasOne(d => d.InvitedBy).WithMany(p => p.Invitations)
                .HasForeignKey(d => d.InvitedById)
                .HasConstraintName("FK__invitatio__invit__03F0984C");

            entity.HasOne(d => d.Recipient).WithMany(p => p.Invitations)
                .HasForeignKey(d => d.RecipientId)
                .HasConstraintName("FK__invitatio__recip__04E4BC85");
        });

        modelBuilder.Entity<InvitedBy>(entity =>
        {
            entity.HasKey(e => e.InvitedById).HasName("PK__invited___0276AD174DCF4884");

            entity.ToTable("invited_by");

            entity.Property(e => e.InvitedById).HasColumnName("invited_by_id");
            entity.Property(e => e.Default).HasColumnName("DEFAULT_");
            entity.Property(e => e.FunctionId).HasColumnName("function_id");
            entity.Property(e => e.InvitedByName)
                .HasMaxLength(30)
                .HasColumnName("invited_by_name");
            entity.Property(e => e.Relation)
                .HasMaxLength(30)
                .HasColumnName("relation");

            entity.HasOne(d => d.Function).WithMany(p => p.InvitedBies)
                .HasForeignKey(d => d.FunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__invited_b__funct__00200768");
        });

        modelBuilder.Entity<PriceBook>(entity =>
        {
            entity.HasKey(e => e.PriceBookId).HasName("PK__price_bo__7F692EF27BA475DE");

            entity.ToTable("price_book");

            entity.Property(e => e.PriceBookId).HasColumnName("price_book_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.BasePackage)
                .HasMaxLength(80)
                .HasColumnName("base_package");
            entity.Property(e => e.BasePackageCardCount).HasColumnName("base_package_card_count");
            entity.Property(e => e.BasePackagePrice)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("base_package_price");
            entity.Property(e => e.BasePackageVideoCount).HasColumnName("base_package_video_count");
            entity.Property(e => e.Charges1001To1500)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("charges_1001_to_1500");
            entity.Property(e => e.Charges1501To2000)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("charges_1501_to_2000");
            entity.Property(e => e.Charges1To1000)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("charges_1_to_1000");
            entity.Property(e => e.Charges2001Above)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("charges_2001_above");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.ExtraCardPriceEach)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("extra_card_price_each");
            entity.Property(e => e.ExtraVideoPriceEach)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("extra_video_price_each");
            entity.Property(e => e.FunctionType)
                .HasMaxLength(80)
                .HasColumnName("function_type");
            entity.Property(e => e.PriceBookName)
                .HasMaxLength(80)
                .HasColumnName("price_book_name");
            entity.Property(e => e.ReminderCharges)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("reminder_charges");
        });

        modelBuilder.Entity<Recipient>(entity =>
        {
            entity.HasKey(e => e.RecipientId).HasName("PK__Recipien__FA0A4027F76DCF05");

            entity.ToTable("Recipient");

            entity.Property(e => e.RecipientId).HasColumnName("recipient_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.AllMarriedDaughters)
                .HasMaxLength(255)
                .HasColumnName("all_married_daughters");
            entity.Property(e => e.AvailableOnWhatsapp).HasColumnName("available_on_whatsapp");
            entity.Property(e => e.BloodGroup)
                .HasMaxLength(10)
                .HasColumnName("blood_group");
            entity.Property(e => e.BloodRequestReceived).HasColumnName("blood_request_received");
            entity.Property(e => e.BloodRequestSentCount).HasColumnName("blood_request_sent_count");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.CompleteFamilyId).HasColumnName("complete_family_id");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(3)
                .HasColumnName("country_code");
            entity.Property(e => e.CurrentLocation)
                .HasMaxLength(50)
                .HasColumnName("current_location");
            entity.Property(e => e.DataCollectionId)
                .HasMaxLength(8)
                .HasColumnName("data_collection_id");
            entity.Property(e => e.Dead).HasColumnName("dead");
            entity.Property(e => e.Education)
                .HasMaxLength(50)
                .HasColumnName("education");
            entity.Property(e => e.EducationCategory)
                .HasMaxLength(50)
                .HasColumnName("education_category");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FamilyTreeId).HasColumnName("family_tree_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .HasColumnName("first_name");
            entity.Property(e => e.ForeignResidence)
                .HasMaxLength(50)
                .HasColumnName("foreign_residence");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .HasColumnName("gender");
            entity.Property(e => e.Gotra)
                .HasMaxLength(50)
                .HasColumnName("gotra");
            entity.Property(e => e.HindiFirstName)
                .HasMaxLength(30)
                .HasColumnName("hindi_first_name");
            entity.Property(e => e.HindiLastName)
                .HasMaxLength(30)
                .HasColumnName("hindi_last_name");
            entity.Property(e => e.HindiMiddleName)
                .HasMaxLength(30)
                .HasColumnName("hindi_middle_name");
            entity.Property(e => e.HindiRecipientName)
                .HasMaxLength(90)
                .HasColumnName("hindi_recipient_name");
            entity.Property(e => e.HindiSalutation)
                .HasMaxLength(30)
                .HasColumnName("hindi_salutation");
            entity.Property(e => e.KnownAs)
                .HasMaxLength(20)
                .HasColumnName("known_as");
            entity.Property(e => e.Kul)
                .HasMaxLength(50)
                .HasColumnName("kul");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.MarathiFirstName)
                .HasMaxLength(30)
                .HasColumnName("marathi_first_name");
            entity.Property(e => e.MarathiLastName)
                .HasMaxLength(30)
                .HasColumnName("marathi_last_name");
            entity.Property(e => e.MarathiMiddleName)
                .HasMaxLength(30)
                .HasColumnName("marathi_middle_name");
            entity.Property(e => e.MarathiRecipientName)
                .HasMaxLength(90)
                .HasColumnName("marathi_recipient_name");
            entity.Property(e => e.MarathiSalutationDel)
                .HasMaxLength(30)
                .HasColumnName("marathi_salutation_del");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(30)
                .HasColumnName("middle_name");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.Occupation)
                .HasMaxLength(50)
                .HasColumnName("occupation");
            entity.Property(e => e.OccupationCategory)
                .HasMaxLength(50)
                .HasColumnName("occupation_category");
            entity.Property(e => e.RecipientName)
                .HasMaxLength(80)
                .HasColumnName("recipient_name");
            entity.Property(e => e.RelationshipStatus)
                .HasMaxLength(30)
                .HasColumnName("relationship_status");
            entity.Property(e => e.Salutation)
                .HasMaxLength(50)
                .HasColumnName("salutation");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.VillageId).HasColumnName("village_id");
            entity.Property(e => e.WhatsappNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("whatsapp_number");

            entity.HasOne(d => d.Community).WithMany(p => p.Recipients)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("FK__Recipient__commu__6754599E");

            entity.HasOne(d => d.Father).WithMany(p => p.InverseFather)
                .HasForeignKey(d => d.FatherId)
                .HasConstraintName("FK__Recipient__Fathe__68487DD7");

            entity.HasOne(d => d.Mother).WithMany(p => p.InverseMother)
                .HasForeignKey(d => d.MotherId)
                .HasConstraintName("FK__Recipient__Mothe__693CA210");

            entity.HasOne(d => d.Spouse).WithMany(p => p.InverseSpouse)
                .HasForeignKey(d => d.SpouseId)
                .HasConstraintName("FK__Recipient__Spous__6A30C649");

            entity.HasOne(d => d.Village).WithMany(p => p.Recipients)
                .HasForeignKey(d => d.VillageId)
                .HasConstraintName("FK__Recipient__villa__6B24EA82");
        });

        modelBuilder.Entity<SampleCard>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("PK__sample_c__BDF201DDA79352D1");

            entity.ToTable("sample_card");

            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.CardDesignerId).HasColumnName("card_designer_id");
            entity.Property(e => e.Colour)
                .HasMaxLength(255)
                .HasColumnName("colour");
            entity.Property(e => e.FunctionType)
                .HasMaxLength(255)
                .HasColumnName("function_type");
            entity.Property(e => e.Language)
                .HasMaxLength(255)
                .HasColumnName("language");
            entity.Property(e => e.SampleCardName)
                .HasMaxLength(80)
                .HasColumnName("sample_card_name");
            entity.Property(e => e.Theme)
                .HasMaxLength(255)
                .HasColumnName("theme");

            entity.HasOne(d => d.CardDesigner).WithMany(p => p.SampleCards)
                .HasForeignKey(d => d.CardDesignerId)
                .HasConstraintName("FK__sample_ca__card___07C12930");
        });

        modelBuilder.Entity<SampleVideo>(entity =>
        {
            entity.HasKey(e => e.SampleVideoId).HasName("PK__sample_v__B6D0A7EE24FC1605");

            entity.ToTable("sample_video");

            entity.Property(e => e.SampleVideoId).HasColumnName("sample_video_id");
            entity.Property(e => e.DurationSec)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("duration_sec");
            entity.Property(e => e.FunctionType)
                .HasMaxLength(255)
                .HasColumnName("function_type");
            entity.Property(e => e.Language)
                .HasMaxLength(255)
                .HasColumnName("language");
            entity.Property(e => e.Relation)
                .HasMaxLength(255)
                .HasColumnName("relation");
            entity.Property(e => e.SampleVideoName)
                .HasMaxLength(80)
                .HasColumnName("sample_video_name");
            entity.Property(e => e.VideoCreatorId).HasColumnName("Video_Creator_id");

            entity.HasOne(d => d.VideoCreator).WithMany(p => p.SampleVideos)
                .HasForeignKey(d => d.VideoCreatorId)
                .HasConstraintName("FK__sample_vi__Video__0A9D95DB");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__state__81A47417A82A873C");

            entity.ToTable("state");

            entity.Property(e => e.StateId).HasColumnName("state_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.StateCode)
                .HasMaxLength(2)
                .HasColumnName("state_code");
            entity.Property(e => e.StateName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("state_name");
        });

        modelBuilder.Entity<SubDistrict>(entity =>
        {
            entity.ToTable("sub_district");

            entity.Property(e => e.SubDistrictId).HasColumnName("sub_district_id");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.SubDistrictCode)
                .HasMaxLength(3)
                .HasColumnName("sub_district_code");
            entity.Property(e => e.SubDistrictName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("sub_district_name");

            entity.HasOne(d => d.District).WithMany(p => p.SubDistricts)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_subdistrict_district");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__vendor__0F7D2B786A7143D2");

            entity.ToTable("vendor");

            entity.Property(e => e.VendorId).HasColumnName("vendor_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.HasLaptop).HasColumnName("has_laptop");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .HasColumnName("phone");
            entity.Property(e => e.VendorName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vendor_name");
            entity.Property(e => e.VendorType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("vendor_type");
            entity.Property(e => e.VillageId).HasColumnName("village_id");

            entity.HasOne(d => d.Village).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.VillageId)
                .HasConstraintName("FK__vendor__village___5FB337D6");
        });

        modelBuilder.Entity<Village>(entity =>
        {
            entity.HasKey(e => e.VillageId).HasName("PK__Village__71031D95061094DD");

            entity.ToTable("Village");

            entity.Property(e => e.VillageId).HasColumnName("village_id");
            entity.Property(e => e.PinCode)
                .HasMaxLength(6)
                .HasColumnName("pin_code");
            entity.Property(e => e.SubDistrictId).HasColumnName("sub_district_id");
            entity.Property(e => e.VillageCode)
                .HasMaxLength(30)
                .HasColumnName("village_code");
            entity.Property(e => e.VillageName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("village_name");

            entity.HasOne(d => d.SubDistrict).WithMany(p => p.Villages)
                .HasForeignKey(d => d.SubDistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Village__sub_dis__5CD6CB2B");
        });

        modelBuilder.Entity<WhatsappMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__whatsapp__0BBF6EE65ACE1B27");

            entity.ToTable("whatsapp_message");

            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.AcceptedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("accepted_datetime");
            entity.Property(e => e.ApiErrorDatetime)
                .HasColumnType("datetime")
                .HasColumnName("api_error_datetime");
            entity.Property(e => e.ApiErrorMessage)
                .HasMaxLength(3000)
                .HasColumnName("api_error_message");
            entity.Property(e => e.DeletedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("deleted_datetime");
            entity.Property(e => e.DeliveredDatetime)
                .HasColumnType("datetime")
                .HasColumnName("delivered_datetime");
            entity.Property(e => e.FailedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("failed_datetime");
            entity.Property(e => e.FinalStatus)
                .HasMaxLength(30)
                .HasColumnName("final_status");
            entity.Property(e => e.FunctionIdText)
                .HasMaxLength(30)
                .HasColumnName("function_id_text");
            entity.Property(e => e.InvitationId).HasColumnName("invitation_id");
            entity.Property(e => e.InvitationType)
                .HasMaxLength(30)
                .HasColumnName("invitation_type");
            entity.Property(e => e.LanguageCode)
                .HasMaxLength(30)
                .HasColumnName("language_code");
            entity.Property(e => e.MediaType)
                .HasMaxLength(30)
                .HasColumnName("media_type");
            entity.Property(e => e.ReadDatetime)
                .HasColumnType("datetime")
                .HasColumnName("read_datetime");
            entity.Property(e => e.RecipientWhatsappNumber)
                .HasMaxLength(15)
                .HasColumnName("recipient_whatsapp_number");
            entity.Property(e => e.SentDatetime)
                .HasColumnType("datetime")
                .HasColumnName("sent_datetime");
            entity.Property(e => e.SequenceNumber).HasColumnName("sequence_number");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");
            entity.Property(e => e.TemplateStructureId).HasColumnName("template_structure_id");
            entity.Property(e => e.VariableSequence)
                .HasMaxLength(10)
                .HasColumnName("variable_sequence");

            entity.HasOne(d => d.Invitation).WithMany(p => p.WhatsappMessages)
                .HasForeignKey(d => d.InvitationId)
                .HasConstraintName("FK__whatsapp___invit__160F4887");

            entity.HasOne(d => d.TemplateStructure).WithMany(p => p.WhatsappMessages)
                .HasForeignKey(d => d.TemplateStructureId)
                .HasConstraintName("FK__whatsapp___templ__151B244E");
        });

        modelBuilder.Entity<WhatsappTemplate>(entity =>
        {
            entity.HasKey(e => e.TemplateId).HasName("PK__whatsapp__BE44E07915F0D91B");

            entity.ToTable("whatsapp_template");

            entity.Property(e => e.TemplateId).HasColumnName("template_id");
            entity.Property(e => e.Category)
                .HasMaxLength(30)
                .HasColumnName("category");
            entity.Property(e => e.HeaderType)
                .HasMaxLength(30)
                .HasColumnName("header_type");
            entity.Property(e => e.InvitationType)
                .HasMaxLength(30)
                .HasColumnName("invitation_type");
            entity.Property(e => e.Language)
                .HasMaxLength(20)
                .HasColumnName("language");
            entity.Property(e => e.LanguageCode)
                .HasMaxLength(10)
                .HasColumnName("language_code");
            entity.Property(e => e.MediaType)
                .HasMaxLength(30)
                .HasColumnName("media_type");
            entity.Property(e => e.TemplateName)
                .HasMaxLength(80)
                .HasColumnName("template_name");
            entity.Property(e => e.VariableCount).HasColumnName("variable_count");
            entity.Property(e => e.VariableSequence)
                .HasMaxLength(255)
                .HasColumnName("variable_sequence");
        });

        modelBuilder.Entity<WhatsappTemplateStructure>(entity =>
        {
            entity.HasKey(e => e.TemplateStructureId).HasName("PK__whatsapp__F320AABE105DE5AC");

            entity.ToTable("whatsapp_template_structure");

            entity.Property(e => e.TemplateStructureId).HasColumnName("template_structure_id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.DocumentFileName)
                .HasMaxLength(100)
                .HasColumnName("document_file_name");
            entity.Property(e => e.FooterText)
                .HasMaxLength(60)
                .HasColumnName("footer_text");
            entity.Property(e => e.FunctionId).HasColumnName("function_id");
            entity.Property(e => e.HeaderText)
                .HasMaxLength(60)
                .HasColumnName("header_text");
            entity.Property(e => e.IsDefault).HasColumnName("is_default");
            entity.Property(e => e.Language)
                .HasMaxLength(30)
                .HasColumnName("language");
            entity.Property(e => e.LocationAddress).HasColumnName("location_address");
            entity.Property(e => e.LocationLatitude)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("location_latitude");
            entity.Property(e => e.LocationLongitude)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("location_longitude");
            entity.Property(e => e.LocationName)
                .HasMaxLength(80)
                .HasColumnName("location_name");
            entity.Property(e => e.MediaCaption)
                .HasMaxLength(100)
                .HasColumnName("media_caption");
            entity.Property(e => e.MediaId)
                .HasMaxLength(50)
                .HasColumnName("media_id");
            entity.Property(e => e.MediaLink).HasColumnName("media_link");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .HasColumnName("name");
            entity.Property(e => e.SampleVideoId).HasColumnName("sample_video_id");
            entity.Property(e => e.SequenceNumber).HasColumnName("sequence_number");
            entity.Property(e => e.TemplateId).HasColumnName("template_id");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.Card).WithMany(p => p.WhatsappTemplateStructures)
                .HasForeignKey(d => d.CardId)
                .HasConstraintName("FK__whatsapp___card___114A936A");

            entity.HasOne(d => d.Function).WithMany(p => p.WhatsappTemplateStructures)
                .HasForeignKey(d => d.FunctionId)
                .HasConstraintName("FK__whatsapp___funct__0F624AF8");

            entity.HasOne(d => d.SampleVideo).WithMany(p => p.WhatsappTemplateStructures)
                .HasForeignKey(d => d.SampleVideoId)
                .HasConstraintName("FK__whatsapp___sampl__10566F31");

            entity.HasOne(d => d.Template).WithMany(p => p.WhatsappTemplateStructures)
                .HasForeignKey(d => d.TemplateId)
                .HasConstraintName("FK__whatsapp___templ__123EB7A3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

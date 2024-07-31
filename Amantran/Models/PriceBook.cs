using System;
using System.Collections.Generic;

namespace Amantran.Models;

public partial class PriceBook
{
    public int PriceBookId { get; set; }

    public string PriceBookName { get; set; } = null!;

    public string? FunctionType { get; set; }

    public decimal? Charges1To1000 { get; set; }

    public decimal? Charges1001To1500 { get; set; }

    public decimal? Charges1501To2000 { get; set; }

    public decimal? Charges2001Above { get; set; }

    public string? BasePackage { get; set; }

    public decimal? BasePackagePrice { get; set; }

    public decimal? ExtraCardPriceEach { get; set; }

    public decimal? ExtraVideoPriceEach { get; set; }

    public bool Active { get; set; }

    public string? Description { get; set; }

    public int? BasePackageCardCount { get; set; }

    public int? BasePackageVideoCount { get; set; }

    public decimal? ReminderCharges { get; set; }

    public virtual ICollection<Function> Functions { get; set; } = new List<Function>();
}

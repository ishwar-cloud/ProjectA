using System;
using System.Collections.Generic;

namespace Infrastructure.DataContext;

public partial class FieldSequence
{
    public int FieldSequenceId { get; set; }

    public string? TableName { get; set; }

    public string? ColumnName { get; set; }

    public string? Sequence { get; set; }

    public string? SectionName { get; set; }

    public string? SectionSequence { get; set; }

    public string? ColumnLabel { get; set; }

    public string? Datatype { get; set; }

    public string? Value { get; set; }

    public string? LookupFieldUi { get; set; }

    public bool? Required { get; set; }

    public string? LookupFilterSource { get; set; }

    public string? LookupFilterData { get; set; }
}

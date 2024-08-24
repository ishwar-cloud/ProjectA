using Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DynamicFormController : Controller
{
    private readonly AmantranContext _context;

    public DynamicFormController(AmantranContext context)
    {
        _context = context;
    }

    // Action to display the form
    public async Task<IActionResult> CreateForm()
    {
        var fieldMetadata = await GetFieldMetadataAsync();
        var model = new DynamicFormViewModel
        {
            FieldMetadata = fieldMetadata
        };
        return View(model);
    }

    // Action to handle form submission
    [HttpPost]
    public IActionResult SubmitForm(IFormCollection formData)
    {
        // Process form submission here
        // Extract form values from formData

        // Example: Print form data to console
        foreach (var key in formData.Keys)
        {
            var value = formData[key];
            System.Diagnostics.Debug.WriteLine($"{key}: {value}");
        }

        // Redirect to a success page or perform further actions
        return RedirectToAction("Success");
    }

    // Action to show success message
    public IActionResult Success()
    {
        return View();
    }

    // Helper method to get field metadata from the database
    private async Task<List<FieldSequence>> GetFieldMetadataAsync()
    {
        return await _context.FieldSequences
            .Select(f => new FieldSequence
            {
                FieldSequenceId = f.FieldSequenceId,
                TableName = f.TableName,
                ColumnName = f.ColumnName,
                Sequence = f.Sequence,
                SectionName = f.SectionName,
                SectionSequence = f.SectionSequence,
                ColumnLabel = f.ColumnLabel,
                Datatype = f.Datatype,
                Value = f.Value,
                LookupFieldUi = f.LookupFieldUi,
                Required = f.Required,
                LookupFilterSource = f.LookupFilterSource,
                LookupFilterData = f.LookupFilterData
            })
            .ToListAsync();
    }
}

// ViewModel to pass field metadata to the view
public class DynamicFormViewModel
{
    public List<FieldSequence> FieldMetadata { get; set; }
}

// Model representing field metadata
public class FieldSequence
{
    public int FieldSequenceId { get; set; }
    public string TableName { get; set; }
    public string ColumnName { get; set; }
    public string Sequence { get; set; }
    public string SectionName { get; set; }
    public string SectionSequence { get; set; }
    public string ColumnLabel { get; set; }
    public string Datatype { get; set; }
    public string Value { get; set; }
    public string LookupFieldUi { get; set; }
    public bool? Required { get; set; }
    public string LookupFilterSource { get; set; }
    public string LookupFilterData { get; set; }
}

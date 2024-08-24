using Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amantran.Controllers
{
    public class FieldSequenceController : Controller
    {
        private readonly AmantranContext _context;

        public FieldSequenceController(AmantranContext context)
        {
            _context = context;
        }

        // GET: FieldSequence
        public async Task<IActionResult> Index()
        {
            var fieldSequences = await _context.FieldSequences
        .OrderByDescending(fs => fs.Sequence) // Sort in descending order
        .ToListAsync();
            return View(fieldSequences);
        }

        // GET: FieldSequence/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FieldSequence/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TableName,ColumnName,Sequence,SectionName,SectionSequence,ColumnLabel,Datatype,Value,LookupFieldUi,Required,LookupFilterSource,LookupFilterData")] FieldSequence fieldSequence)
        {
            
                // FieldSequenceID is automatically handled by the database
                _context.Add(fieldSequence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(fieldSequence);
        }

        // GET: FieldSequence/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var fieldSequence = await _context.FieldSequences.FindAsync(id);
            if (fieldSequence == null)
            {
                return NotFound();
            }
            return View(fieldSequence);
        }

        // POST: FieldSequence/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FieldSequenceId,TableName,ColumnName,Sequence,SectionName,SectionSequence,ColumnLabel,Datatype,Value,LookupFieldUi,Required,LookupFilterSource,LookupFilterData")] FieldSequence fieldSequence)
        {
            if (id != fieldSequence.FieldSequenceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fieldSequence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldSequenceExists(fieldSequence.FieldSequenceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fieldSequence);
        }


        // GET: FieldSequence/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var fieldSequence = await _context.FieldSequences
                .FirstOrDefaultAsync(m => m.FieldSequenceId == id);
            if (fieldSequence == null)
            {
                return NotFound();
            }

            return View(fieldSequence);
        }

        // POST: FieldSequence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fieldSequence = await _context.FieldSequences.FindAsync(id);
            if (fieldSequence == null)
            {
                return NotFound();
            }

            _context.FieldSequences.Remove(fieldSequence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool FieldSequenceExists(int id)
        {
            return _context.FieldSequences.Any(e => e.FieldSequenceId == id);
        }
    }
}

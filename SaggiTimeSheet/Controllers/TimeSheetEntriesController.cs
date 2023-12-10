using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaggiTimeSheet;
using SaggiTimeSheet.Models;

namespace SaggiTimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetEntriesController : ControllerBase
    {
        private readonly SaggiTimeSheetDbContext _context;

        public TimeSheetEntriesController(SaggiTimeSheetDbContext context)
        {
            _context = context;
        }

        // GET: api/TimeSheetEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeSheetEntry>>> Gettimesheetentries()
        {
          if (_context.timesheetentries == null)
          {
              return NotFound();
          }
            return await _context.timesheetentries.ToListAsync();
        }

        // GET: api/TimeSheetEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSheetEntry>> GetTimeSheetEntry(int id)
        {
          if (_context.timesheetentries == null)
          {
              return NotFound();
          }
            var timeSheetEntry = await _context.timesheetentries.FindAsync(id);

            if (timeSheetEntry == null)
            {
                return NotFound();
            }

            return timeSheetEntry;
        }

        // PUT: api/TimeSheetEntries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeSheetEntry(int id, TimeSheetEntry timeSheetEntry)
        {
            if (id != timeSheetEntry.TimeSheetEntryId)
            {
                return BadRequest();
            }

            _context.Entry(timeSheetEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeSheetEntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TimeSheetEntries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TimeSheetEntry>> PostTimeSheetEntry(TimeSheetEntry timeSheetEntry)
        {
          if (_context.timesheetentries == null)
          {
              return Problem("Entity set 'SaggiTimeSheetDbContext.timesheetentries'  is null.");
          }
            _context.timesheetentries.Add(timeSheetEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeSheetEntry", new { id = timeSheetEntry.TimeSheetEntryId }, timeSheetEntry);
        }

        // DELETE: api/TimeSheetEntries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeSheetEntry(int id)
        {
            if (_context.timesheetentries == null)
            {
                return NotFound();
            }
            var timeSheetEntry = await _context.timesheetentries.FindAsync(id);
            if (timeSheetEntry == null)
            {
                return NotFound();
            }

            _context.timesheetentries.Remove(timeSheetEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeSheetEntryExists(int id)
        {
            return (_context.timesheetentries?.Any(e => e.TimeSheetEntryId == id)).GetValueOrDefault();
        }
    }
}

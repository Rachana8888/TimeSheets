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
    public class TimeSheetsController : ControllerBase
    {
        private readonly SaggiTimeSheetDbContext _context;

        public TimeSheetsController(SaggiTimeSheetDbContext context)
        {
            _context = context;
        }

        // GET: api/TimeSheets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeSheet>>> Gettimesheets()
        {
          if (_context.timesheets == null)
          {
              return NotFound();
          }
            return await _context.timesheets.ToListAsync();
        }

        // GET: api/TimeSheets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSheet>> GetTimeSheet(int id)
        {
          if (_context.timesheets == null)
          {
              return NotFound();
          }
            var timeSheet = await _context.timesheets.FindAsync(id);

            if (timeSheet == null)
            {
                return NotFound();
            }

            return timeSheet;
        }

        // PUT: api/TimeSheets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeSheet(int id, TimeSheet timeSheet)
        {
            if (id != timeSheet.TimeSheetId)
            {
                return BadRequest();
            }

            _context.Entry(timeSheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeSheetExists(id))
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

        // POST: api/TimeSheets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TimeSheet>> PostTimeSheet(TimeSheet timeSheet)
        {
          if (_context.timesheets == null)
          {
              return Problem("Entity set 'SaggiTimeSheetDbContext.timesheets'  is null.");
          }
            _context.timesheets.Add(timeSheet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeSheet", new { id = timeSheet.TimeSheetId }, timeSheet);
        }

        // DELETE: api/TimeSheets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeSheet(int id)
        {
            if (_context.timesheets == null)
            {
                return NotFound();
            }
            var timeSheet = await _context.timesheets.FindAsync(id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            _context.timesheets.Remove(timeSheet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeSheetExists(int id)
        {
            return (_context.timesheets?.Any(e => e.TimeSheetId == id)).GetValueOrDefault();
        }
    }
}

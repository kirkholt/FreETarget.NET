using FreETarget.NET.Data;
using FreETarget.NET.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Range = FreETarget.NET.Data.Entities.Range;

namespace FreETarget.NET.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RangeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly DataService _dataService;  

        public RangeController(AppDbContext context)
        {
            _context = context;
            _dataService = new DataService(context);
        }

        // GET: api/Range
        [HttpGet]
        public async Task<IEnumerable<Range>> GetRangeDbSet()
        {
            return await _dataService.RangeGet();
        }

        // GET: api/Range/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Range>> GetRange(Guid id)
        {
            var range = await _context.RangeDbSet.FindAsync(id);

            if (range == null)
            {
                return NotFound();
            }

            return range;
        }

        // PUT: api/Range/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRange(Guid id, Range range)
        {
            if (id != range.Id)
            {
                return BadRequest();
            }

            _context.Entry(range).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RangeExists(id))
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

        // POST: api/Range
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Range>> PostRange(Range range)
        {
            _context.RangeDbSet.Add(range);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRange", new { id = range.Id }, range);
        }

        // DELETE: api/Range/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRange(Guid id)
        {
            var range = await _context.RangeDbSet.FindAsync(id);
            if (range == null)
            {
                return NotFound();
            }

            _context.RangeDbSet.Remove(range);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RangeExists(Guid id)
        {
            return _context.RangeDbSet.Any(e => e.Id == id);
        }
    }
}

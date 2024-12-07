using FreETarget.NET.Data;
using FreETarget.NET.Data.Enums;
using FreETarget.NET.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Range = FreETarget.NET.Data.Entities.Range;

namespace FreETarget.NET.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RangeController : FreETargetControllerBase
    {
        private readonly DataService _dataService;

        public RangeController(AppDbContext context)
        {
            _dataService = new DataService(context);
        }

        // GET: api/Range
        [HttpGet]
        public async Task<List<Range>> GetRangeDbSet(CancellationToken cancellationToken)
        {
            return await _dataService.RangeGet(cancellationToken);
        }

        // GET: api/Range/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Range>> GetRange(Guid id, CancellationToken cancellationToken)
        {

            Range? range = await _dataService.RangeGet(id, cancellationToken);

            if (range == null)
            {
                return NotFound();
            }
            return Ok(range);
        }

        // PUT: api/Range/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRange(Guid id, Range range, CancellationToken cancellationToken)
        {
            SaveResult saveResult;
            if (id != range.Id)
            {
                saveResult = SaveResult.BadRequest;
            }
            else
            {
                saveResult = await _dataService.RangePut(range, cancellationToken);
            }   
            return base.SaveResultActionResult(saveResult);
        }

        // POST: api/Range
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Range>> PostRange(Range range)
        {
            await _dataService.RangePost(range);
            return CreatedAtAction("GetRange", new { id = range.Id }, range);
        }

        // DELETE: api/Range/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRange(Guid id, CancellationToken cancellationToken)
        {
            SaveResult saveResult = await _dataService.RangeDelete(id, cancellationToken);
            return base.SaveResultActionResult(saveResult);
        }
    }
}

using FreETarget.NET.Data;
using FreETarget.NET.Data.Enums;
using FreETarget.NET.Data.Models.DTO;
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRange(Guid id, RangeDTO rangeDTO, CancellationToken cancellationToken)
        {
            SaveResult saveResult;
            if (id != rangeDTO.Id)
            {
                saveResult = SaveResult.BadRequest;
            }
            else
            {
                saveResult = await _dataService.RangePut(rangeDTO, cancellationToken);
            }   
            return base.SaveResultActionResult(saveResult);
        }

        // POST: api/Range
        [HttpPost]
        public async Task<ActionResult<Range>> PostRange(RangeDTO rangeDTO)
        {
            Range range = await _dataService.RangePost(rangeDTO);
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

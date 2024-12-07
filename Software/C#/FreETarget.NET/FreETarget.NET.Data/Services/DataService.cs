using FreETarget.NET.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Range = FreETarget.NET.Data.Entities.Range;

namespace FreETarget.NET.Data.Services
{
    public class DataService
    {
        private readonly AppDbContext _context;

        public DataService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SaveResult> RangeDelete(Guid id, CancellationToken cancellationToken = default)
        {
            Range? range = await RangeGet(id, cancellationToken);
            if (range == null)
            {
                return SaveResult.NotFound;
            }

            _context.RangeDbSet.Remove(range);
            await _context.SaveChangesAsync();
            return SaveResult.Ok;
        }

        private async Task<bool> RangeExists(Guid id, CancellationToken cancellationToken = default)
        {
            return await RangeGet(id, cancellationToken) != null;
        }

        public async Task<List<Range>> RangeGet(CancellationToken cancellationToken = default)
        {
            return await _context.RangeDbSet.ToListAsync(cancellationToken);

        }

        public async Task<Range?> RangeGet(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.RangeDbSet.Where(w => w.Id == id).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<Range> RangePost(Range range, CancellationToken cancellationToken = default)
        {
            _context.RangeDbSet.Add(range);
            await _context.SaveChangesAsync(cancellationToken);
            return range;
        }

        public async Task<SaveResult> RangePut(Range range, CancellationToken cancellationToken = default)
        {
            _context.Entry(range).State = EntityState.Modified;

            try
            {
                var x = await _context.SaveChangesAsync();
                return SaveResult.Ok;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RangeExists(range.Id, cancellationToken))
                {
                    return SaveResult.NotFound;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}

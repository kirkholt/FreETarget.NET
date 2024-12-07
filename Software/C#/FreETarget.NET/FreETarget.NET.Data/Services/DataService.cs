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

        public async Task<IEnumerable<Range>> RangeGet(CancellationToken cancellationToken = default)
        {
            return await _context.RangeDbSet.ToListAsync(cancellationToken);
        }

        public async Task<Range> RangeGet(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.RangeDbSet.Where(w => w.Id == id).SingleAsync(cancellationToken);
        }


    }
}

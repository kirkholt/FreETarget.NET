using FreETarget.NET.Data.Enums;
using FreETarget.NET.Data.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Track = FreETarget.NET.Data.Entities.Track;
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

        #region Range
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
            return await _context.RangeDbSet.AsNoTracking().Where(w => w.Id == id).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<Range> RangePost(RangeDTO  rangeDTO , CancellationToken cancellationToken = default)
        {
           Range range = new Range(rangeDTO);
            _context.RangeDbSet.Add(range);
            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            return range;
        }

        public async Task<SaveResult> RangePut(RangeDTO rangeDTO, CancellationToken cancellationToken = default)
        {
            SaveResult saveResult;
            Range range = new Range(rangeDTO);
            _context.Entry(range).State = EntityState.Modified;

            try
            {
                var x = await _context.SaveChangesAsync();
                saveResult = SaveResult.Ok;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RangeExists(range.Id, cancellationToken))
                {
                    saveResult = SaveResult.NotFound;
                }
                else
                {
                    throw;
                }
            }
            _context.ChangeTracker.Clear();
            return saveResult;
        }
        #endregion

        #region Track
        public async Task<SaveResult> TrackDelete(Guid id, CancellationToken cancellationToken = default)
        {
            Track? track = await TrackGet(id, cancellationToken);
            if (track == null)
            {
                return SaveResult.NotFound;
            }

            _context.TrackDbSet.Remove(track);
            await _context.SaveChangesAsync();
            return SaveResult.Ok;
        }

        private async Task<bool> TrackExists(Guid id, CancellationToken cancellationToken = default)
        {
            return await TrackGet(id, cancellationToken) != null;
        }

        public async Task<List<Track>> TrackGet(CancellationToken cancellationToken = default)
        {
            return await _context.TrackDbSet
                .Include(i => i.Range)
                .ToListAsync(cancellationToken);
        }

        public async Task<Track?> TrackGet(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.TrackDbSet
                .Include( i => i.Range)
                .AsNoTracking().Where(w => w.Id == id).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<Track> TrackPost(TrackDTO trackDTO, CancellationToken cancellationToken = default)
        {
            Track track = new(trackDTO);

            _context.TrackDbSet.Add(track);
            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            return track;
        }

        public async Task<SaveResult> TrackPut(TrackDTO trackDTO, CancellationToken cancellationToken = default)
        {
            SaveResult saveResult;
            Track track = new(trackDTO);
            _context.Entry(track).State = EntityState.Modified;

            try
            {
                var x = await _context.SaveChangesAsync();
                saveResult= SaveResult.Ok;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TrackExists(trackDTO.Id, cancellationToken))
                {
                    saveResult = SaveResult.NotFound;
                }
                else
                {
                    throw;
                }
            }
            _context.ChangeTracker.Clear();
            return saveResult;
        }
        #endregion

    }
}

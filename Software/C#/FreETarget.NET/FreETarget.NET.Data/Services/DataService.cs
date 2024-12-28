using FreETarget.NET.Data.Enums;
using FreETarget.NET.Data.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Range = FreETarget.NET.Data.Entities.Range;
using FreETarget.NET.Data.Entities;
using FreETarget.NET.Data.Models;
using FreETarget.NET.Data.Models.TargetTypes;
using System;

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

        public async Task<Range> RangePost(RangeDTO rangeDTO, CancellationToken cancellationToken = default)
        {
            Range range = new Range(rangeDTO);
            _context.RangeDbSet.Add(range);
            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            return await RangeGet(rangeDTO.Id, cancellationToken);
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
                .Include(i => i.Target)
                .ToListAsync(cancellationToken);
        }

        public async Task<Track?> TrackGet(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.TrackDbSet
                .Include(i => i.Range)
                .Include(i => i.Target)
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
                saveResult = SaveResult.Ok;
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

        #region Target
        public async Task<SaveResult> TargetDelete(Guid id, CancellationToken cancellationToken = default)
        {
            Target? target = await TargetGet(id, cancellationToken);
            if (target == null)
            {
                return SaveResult.NotFound;
            }

            _context.TargetDbSet.Remove(target);
            await _context.SaveChangesAsync();
            return SaveResult.Ok;
        }

        private async Task<bool> TargetExists(Guid id, CancellationToken cancellationToken = default)
        {
            return await TargetGet(id, cancellationToken) != null;
        }

        public async Task<List<Target>> TargetGet(CancellationToken cancellationToken = default)
        {
            return await _context.TargetDbSet.ToListAsync(cancellationToken);

        }

        public async Task<Target?> TargetGet(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.
                TargetDbSet
                .AsNoTracking()
                .Where(w => w.Id == id)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<Target> TargetPost(Target target, CancellationToken cancellationToken = default)
        {
            _context.TargetDbSet.Add(target);
            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            return await TargetGet(target.Id, cancellationToken);
        }

        public async Task<SaveResult> TargetPut(Target target, CancellationToken cancellationToken = default)
        {
            SaveResult saveResult;
            _context.Entry(target).State = EntityState.Modified;

            try
            {
                var x = await _context.SaveChangesAsync();
                saveResult = SaveResult.Ok;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TargetExists(target.Id, cancellationToken))
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

        #region Session
        public async Task<SaveResult> SessionDelete(Guid id, CancellationToken cancellationToken = default)
        {
            Session? session = await SessionGet(id, cancellationToken);
            if (session == null)
            {
                return SaveResult.NotFound;
            }

            _context.SessionDbSet.Remove(session);
            await _context.SaveChangesAsync();
            return SaveResult.Ok;
        }

        private async Task<bool> SessionExists(Guid id, CancellationToken cancellationToken = default)
        {
            return await SessionGet(id, cancellationToken) != null;
        }

        public async Task<List<Session>> SessionGet(CancellationToken cancellationToken = default)
        {
            return await _context
                .SessionDbSet
                .OrderBy(o => o.CreatedAt)
                .ToListAsync(cancellationToken);

        }

        public async Task<Session?> SessionGet(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context
                .SessionDbSet
                .Include(i => i.Track)
                .ThenInclude(i => i.Range)
                .Include(i => i.ShotList)
                .AsNoTracking()
                .Where(w => w.Id == id)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Session>> SessionGetByTrackId(Guid trackId, CancellationToken cancellationToken = default)
        {
            return await _context
                .SessionDbSet
                .Include(i => i.Track)
                .ThenInclude(i => i.Range)
                .Include(i => i.ShotList)
                .AsNoTracking()
                .Where(w => w.TrackId == trackId)
                .OrderBy(o => o.CreatedAt)
                .ToListAsync(cancellationToken);
        }

        public async Task<Session> SessionGetActiveByTargetId(Guid targetId, CancellationToken cancellationToken = default)
        {
            return await _context
                .SessionDbSet
                .Include(i => i.Track)
                .Include(i => i.Track.Target)
                .Include(i => i.ShotList)
                .AsNoTracking()
                .Where(w => w.Track.TargetId == targetId)
                .Where(w => w.Active)
                .SingleAsync(cancellationToken);
        }

        public async Task<Guid> SessionGetActiveIdByTargetId(Guid targetId, CancellationToken cancellationToken = default)
        {
             var s = await _context
                .SessionDbSet
                .AsNoTracking()
                .Where(w => w.Track.TargetId == targetId)
                .Where(w => w.Active)
                .Select(s => new { s.Id }).FirstAsync(cancellationToken);

            return s.Id;
        }


        public async Task<Session> SessionPost(Session session, CancellationToken cancellationToken = default)
        {
            _context.SessionDbSet.Add(session);
            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();

            // If the session is active, deactivate all other sessions on the same track
            if (session.Active)
            {
                await _context
                     .SessionDbSet
                     .Where(w => w.TrackId == session.TrackId && w.Id != session.Id)
                     .ExecuteUpdateAsync(e => e.SetProperty(x => x.Active, false));
            }
            return await SessionGet(session.Id, cancellationToken);
        }

        public async Task<SaveResult> SessionPut(Session session, CancellationToken cancellationToken = default)
        {
            SaveResult saveResult;
            _context.Entry(session).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // If the session is active, deactivate all other sessions on the same track
                if (session.Active)
                {
                    await _context
                         .SessionDbSet
                         .Where(w => w.TrackId == session.TrackId && w.Id != session.Id)
                         .ExecuteUpdateAsync(e => e.SetProperty(x => x.Active, false));
                }
                saveResult = SaveResult.Ok;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SessionExists(session.Id, cancellationToken))
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

        #region Shot
        public async Task<SaveResult> ShotAdd(ShotDTO shotDTO, CancellationToken cancellationToken = default)
        {
            Session session = await SessionGetActiveByTargetId(shotDTO.TargetId, cancellationToken);

            AddShotResult addShotResult = new AddShotResult();

            Shot shot = new Shot(shotDTO);
            shot.SessionId = session.Id;

            aTargetType? targetType = TargetTypeGet( TargetType.Dgi15Riffel);
            shot.ResultDecimal = targetType?.GetScore(shot.R);

            _context.ShotDbSet.Add(shot);
            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            return SaveResult.Ok;
        }
        #endregion

        public aTargetType? TargetTypeGet(TargetType targetType)
        {
            switch (targetType)
            {
                case TargetType.Dgi15Riffel:
                    return new Models.TargetTypes.Dgi15mRiffel();
                default:
                    return null;

            }
        }
    }
}

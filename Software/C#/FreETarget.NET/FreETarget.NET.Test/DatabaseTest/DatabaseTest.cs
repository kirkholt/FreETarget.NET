 using FreETarget.NET.Data;
using FreETarget.NET.Data.Entities;
using FreETarget.NET.Data.Enums;
using FreETarget.NET.Data.Models.DTO;
using FreETarget.NET.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

namespace FreETarget.NET.Test.DatabaseTest
{
    public abstract class DatabaseTest
    {
        public AppDbContext AppDbContext { get; set; }

        public DataService DataService { get; set; }

        public DatabaseTest(DbContextOptions<AppDbContext> contextOptions)
        {
            AppDbContext = new AppDbContext(contextOptions);
            DataService = new DataService(AppDbContext);
        }

        private void Init()
        {
            AppDbContext.Database.EnsureDeleted();
            AppDbContext.Database.EnsureCreated();
        }

        [Fact]
        public async Task TestRange()
        {
            Init();

            Guid rangeId = Guid.CreateVersion7();
            string rangeName = "Test Range";

            RangeDTO rangeDTO = new()
            {
                Id = rangeId,
                Name = rangeName
            };

            Data.Entities.Range r2 = await DataService.RangePost(rangeDTO);
            Assert.NotNull(r2);
            Assert.Equal(rangeId, r2.Id);
            Assert.Equal(rangeName, r2.Name);
            
            List<Data.Entities.Range> ranges = await DataService.RangeGet();
            Assert.Single(ranges);

            string newRangeName = "New Range Name";
            r2.Name = newRangeName;
            await DataService.RangePut(new RangeDTO(r2));
            
            Data.Entities.Range? r3 = await DataService.RangeGet(rangeId);
            Assert.NotNull(r3);
            Assert.Equal(newRangeName, r3.Name);


            await DataService.RangeDelete(rangeId);
            Assert.Empty(await DataService.RangeGet());

        }

        [Fact]
        public async Task TestTarget()
        {
            Init();

            Guid targetId = Guid.CreateVersion7();
            string targetName = "Test Target";


            Target target = new()
            {
                Id = targetId,
                Name = targetName
            };

            Target t1 = await DataService.TargetPost(target);
            Assert.NotNull( t1);
            Assert.Equal(targetId, t1.Id);
            Assert.Equal(targetName, t1.Name);

            List<Target> list = await DataService.TargetGet();
            Assert.Single(list);

            string newName = "New target name";
            t1.Name = newName;
            await DataService.TargetPut(t1);

            Target t2 = await DataService.TargetGet(targetId);
            Assert.NotNull(t2);
            Assert.Equal(newName, t2.Name);



            SaveResult saveResult = await DataService.TargetDelete(targetId);
            Assert.Equal(SaveResult.Ok, saveResult);
            list = await DataService.TargetGet();
            Assert.Empty(list);
        }

        [Fact]
        public async Task TestTrack()
        {
            Init();

            Guid rangeId = Guid.CreateVersion7();
            string rangeName = "Test Range";


            RangeDTO rangeDTO = new()
            {
                Id = rangeId,
                Name = rangeName
            };

            Data.Entities.Range r = await DataService.RangePost(rangeDTO);

            int trackNo = 1;    
            TrackDTO trackDTO = new()
            {
                RangeId = rangeId,
                No = trackNo
            };

            Track track = await DataService.TrackPost(trackDTO);
            Assert.NotNull(track);
            Assert.Equal(rangeId, track.RangeId);
            Assert.Equal(trackNo, track.No);
            Guid trackGuid = track.Id;

            List<Track> trackList = await DataService.TrackGet();
            Assert.Single(trackList);

            int newTrackNo = 2;
            track.No = newTrackNo;
            await DataService.TrackPut(new TrackDTO(track));

            Track? track1 = await DataService.TrackGet(trackGuid);
            Assert.NotNull(track1);
            Assert.Equal(newTrackNo, track1.No);

            string targetName = "Test Target";
            Target target = new()
            {
                Id = Guid.CreateVersion7(),
                Name = targetName
            };
            target = await DataService.TargetPost(target);

            track1.TargetId = target.Id;
            await DataService.TrackPut(new TrackDTO(track1));   

            Track? track2 = await DataService.TrackGet(trackGuid);
            Assert.NotNull(track2);
            Assert.Equal(target.Id, track2.TargetId);

            SaveResult saveResult= await DataService.TrackDelete(trackGuid);
            Assert.Equal(SaveResult.Ok, saveResult);
            trackList = await DataService.TrackGet();
            Assert.Empty(trackList);
        }

        [Fact]
        public async Task TestSession()
        {
            Init();

            Guid rangeId = Guid.CreateVersion7();
            string rangeName = "Test Range";


            RangeDTO rangeDTO = new()
            {
                Id = rangeId,
                Name = rangeName
            };

            Data.Entities.Range range = await DataService.RangePost(rangeDTO);

            int trackNo = 1;
            TrackDTO trackDTO = new()
            {
                RangeId = rangeId,
                No = trackNo
            };
            Track track = await DataService.TrackPost(trackDTO);

            Session session = new();
            session.TrackId = track.Id;
            session.TargetType = TargetType.Dgi15Riffel;
            session.SessionType = SessionType.Trial;
            session.ResultType = ResultType.Integer;
            
            session = await DataService.SessionPost(session);
            Assert.NotNull(session);
            Assert.Equal(track.Id, session.TrackId);

            List<Session> sessionList = await DataService.SessionGet();
            Assert.Single(sessionList);

            Session session1 = session;
        }
    }
}

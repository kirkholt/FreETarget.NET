using FreETarget.NET.Data.Entities;

namespace FreETarget.NET.Data.Models.DTO
{
    /// <summary>
    /// A track is a place where a single shooter can shoot at a time
    /// A track has a single target
    /// </summary>
    public class TrackDTO
    {
        /// <summary>
        /// Unique identifier of the track
        /// </summary>
        public Guid Id { get; set; } = Guid.CreateVersion7();

        /// <summary>
        /// The number of the track
        /// </summary>
        public int No { get; set; }
        public Guid RangeId { get; set; }

        /// <summary>
        /// The identifier of the target used on the track
        /// </summary>
        public Guid? FreETargetId { get; set; }

        public TrackDTO() { }

        public TrackDTO(Track track)
        {
            this.Id = track.Id;
            this.No = track.No;
            this.RangeId = track.RangeId;
            this.FreETargetId = track.FreETargetId;
        }
    }
}

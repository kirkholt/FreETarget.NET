using FreETarget.NET.Data.Models.DTO;

namespace FreETarget.NET.Data.Entities
{
    /// <summary>
    /// A track is a place where a single shooter can shoot at a time
    /// A track has a single target
    /// </summary>
    public class Track : TrackDTO
    {

        /// <summary>
        /// The range where the track is located
        /// </summary>
        public Range Range { get; set; }

        /// <summary>
        /// The target used on the track
        /// </summary>
        public Target? FreETarget { get; set; }

        // Navigation properties

        /// <summary>
        /// The list of sessions that have been shot on the track
        /// </summary>
        public ICollection<Session> SessionList { get; set; } = new List<Session>();


        /// <summary>
        /// Default constructor
        /// </summary>
        public Track() { }

        /// <summary>
        /// Constructor for a track 
        /// </summary>
        /// <param name="trackDto"></param>
        public Track(TrackDTO trackDTO)
        {
            this.Id = trackDTO.Id;
            this.No = trackDTO.No;
            this.RangeId = trackDTO.RangeId;
            this.TargetId = trackDTO.TargetId;

            if (trackDTO.TargetId != null)
            {
                this.FreETarget = new Target()
                {
                    Id = trackDTO.TargetId.Value
                };
            }
        }
    }
}

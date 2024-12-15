using FreETarget.NET.Data.Models.DTO;

namespace FreETarget.NET.Data.Entities
{
    /// <summary>
    /// A shooting range is a place (ie. club, facility) where shooting sports are practiced.
    /// A club can have multiple ranges (ie. indoor, outdoor, 25m, 50m, 100m, etc.)
    /// It has multiple tracks
    /// </summary>
    public class Range : RangeDTO
    {
        // Navigation properties
        /// <summary>
        /// The list of tracks in the range
        /// </summary>
        public ICollection<Track> TrackList { get; internal set; } = new List<Track>();

        public Range() { }

        public Range(RangeDTO rangeDTO)
        {
            this.Id = rangeDTO.Id;
            this.Name = rangeDTO.Name;  
        }   

    }
}

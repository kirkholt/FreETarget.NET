namespace FreETarget.NET.Data.Entities
{
    /// <summary>
    /// A shooting range is a place (ie. club, facility) where shooting sports are practiced.
    /// A club can have multiple ranges (ie. indoor, outdoor, 25m, 50m, 100m, etc.)
    /// It has multiple tracks
    /// </summary>
    public class Range
    {
        /// <summary>
        /// Unique identifier of the range
        /// </summary>
        public Guid Id { get; set; } = Guid.CreateVersion7();
        
        /// <summary>
        /// The name of the range
        /// </summary>
        public string Name { get; set; } = string.Empty;

        // Navigation properties

        /// <summary>
        /// The list of tracks in the range
        /// </summary>
        public ICollection<Track> TrackList { get; set; } = new List<Track>();
    }
}

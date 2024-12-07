namespace FreETarget.NET.Data.Entities
{
    /// <summary>
    /// A track is a place where a single shooter can shoot at a time
    /// A track has a single target
    /// </summary>
    public class Track
    {
        /// <summary>
        /// Unique identifier of the track
        /// </summary>
        public Guid Id { get; set; } = Guid.CreateVersion7();

        /// <summary>
        /// The range where the track is located
        /// </summary>
        public required Range Range { get; set; }

        /// <summary>
        /// The number of the track
        /// </summary>
        public int No { get; set; }

        /// <summary>
        /// The target used on the track
        /// </summary>
        public FreETarget? FreETarget { get; set; }

        // Navigation properties

        /// <summary>
        /// The list of sessions that have been shot on the track
        /// </summary>
        public ICollection<Session> SessionList { get; set; } = new List<Session>();

        // Foreign keys

        /// <summary>
        /// The identifier of the range where the track is located
        /// </summary>
        public Guid RangeId { get; set; }

        /// <summary>
        /// The identifier of the target used on the track
        /// </summary>
        public Guid? FreETargetId { get; set; }
    }
}

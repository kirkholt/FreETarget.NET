using FreETarget.NET.Data.Enums;

namespace FreETarget.NET.Data.Entities
{

    /// <summary>
    /// A session is a collection of shots on a track
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Unique identifier of the session
        /// </summary>
        public Guid Id { get; set; } = Guid.CreateVersion7();
        
        /// <summary>
        /// The Date and time when the session was created
        /// </summary>
        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        /// <summary>
        /// The track where the session was shot
        /// </summary>
        public Track Track { get; set; }
        
        /// <summary>
        /// Is the session active
        /// </summary>
        /// <remarks>
        /// There can be only one active session per track
        /// When a session is active, it is possible to add shots to it
        /// </remarks>
        public bool Active { get; set; } = true;


        /// <summary>
        /// The type of the target used in the session
        /// </summary>
        public TargetType TargetType { get; set; }
        
        /// <summary>
        /// The type of the session
        /// </summary>
        public SessionType SessionType { get; set; }

        /// <summary>
        /// The type of result for the session
        /// </summary>
        public ResultType ResultType { get; set; } = ResultType.Integer;

        // Navigation properties

        /// <summary>
        /// The list of shots in the session
        /// </summary>
        public ICollection<Shot> ShotList { get; set; } = new List<Shot>();

        // Foreign keys

        /// <summary>
        /// The identifier of the track where the session was shot
        /// </summary>
        public Guid TrackId { get; set; }

    }
}

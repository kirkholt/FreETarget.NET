using FreETarget.NET.Data.Models.ShotResult;

namespace FreETarget.NET.Data.Entities
{
    /// <summary>
    /// A shot is a single bullet fired at a target
    /// </summary>
    public class Shot
    {
        /// <summary>
        /// Unique identifier of the shot
        /// </summary>
        public Guid Id { get; } = Guid.CreateVersion7();

        /// <summary>
        /// The Date and time when the shot was fired
        /// </summary>
        public DateTime CreatedAt { get; } = DateTime.Now;

        /// <summary>
        /// The session where the shot was fired
        /// </summary>
        public required Session Session { get; set; }

        /// <summary>
        /// The number of the shot in the session
        /// </summary>
        public int No { get; set; }

        /// <summary>
        /// The x-coordinates of the shot
        /// </summary>
        public decimal X { get; set; }

        /// <summary>
        /// The y-coordinates of the shot
        /// </summary>
        public decimal Y { get; set; }

        /// <summary>
        /// The radius of the shot
        /// </summary>
        public decimal R { get; set; }

        /// <summary>
        /// The angle of the shot
        /// </summary>
        public decimal A { get; set; }

        public  ShotResult? ShotResult   { get; set; }

        // Foreign keys

        /// <summary>
        /// /// The identifier of the session that the shot belongs to
        /// </summary>
        public Guid SessionId { get; set; }

    }
}

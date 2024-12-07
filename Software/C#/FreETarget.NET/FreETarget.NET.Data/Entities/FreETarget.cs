namespace FreETarget.NET.Data.Entities
{
    /// <summary>
    /// A target is a piece of paper or a electronic device that is used for shooting practice
    /// </summary>
    public class FreETarget
    {
        /// <summary>
        /// Unique identifier of the target
        /// Set in the target hardware
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The track where the target is located
        /// </summary>
        public Track? Track { get; set; }
    }
}

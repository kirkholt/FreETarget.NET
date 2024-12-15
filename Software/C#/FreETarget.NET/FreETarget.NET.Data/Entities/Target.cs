using FreETarget.NET.Data.Models.DTO;

namespace FreETarget.NET.Data.Entities
{
    /// <summary>
    /// A target is a piece of paper or a electronic device that is used for shooting practice
    /// </summary>
    public class Target : TargetIpDTO
    {
        /// <summary>
        /// The name of the target
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the target
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The track where the target is located
        /// </summary>
        public Track? Track { get; set; }
    }
}

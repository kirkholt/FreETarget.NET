using Range = FreETarget.NET.Data.Entities.Range;

namespace FreETarget.NET.Data.Models.DTO
{
    /// <summary>
    /// A shooting range is a place (ie. club, facility) where shooting sports are practiced.
    /// A club can have multiple ranges (ie. indoor, outdoor, 25m, 50m, 100m, etc.)
    /// It has multiple tracks
    /// </summary>
    public class RangeDTO
    {
        /// <summary>
        /// Unique identifier of the range
        /// </summary>
        public Guid Id { get; set; } = Guid.CreateVersion7();

        /// <summary>
        /// The name of the range
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Default constructor
        /// </summary>
        public RangeDTO() { }

        /// <summary>
        /// constructor for a range
        /// </summary>
        /// <param name="range"></param>
        public RangeDTO(Range range)
        {
            this.Id = range.Id;
            this.Name = range.Name;
        }

    }
}

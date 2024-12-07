namespace FreETarget.NET.Data.Models.ShotResult
{
    /// <summary>
    /// The result of a shot
    /// </summary>
    public class ShotResult
    {
        /// <summary>
        /// The decimal result of the shot
        /// </summary>
        public DecimalResult? DecimalResult { get; set; }

        /// <summary>
        /// The integer result of the shot
        /// </summary>
        public IntegerResult? IntegerResult { get; set; }
    }
}

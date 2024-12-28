using FreETarget.NET.Data.Models.DTO;

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
        public Guid Id { get; set; } = Guid.CreateVersion7();

        /// <summary>
        /// The Date and time when the shot was fired
        /// </summary>
        public DateTime CreatedAt { get; } = DateTime.Now;

        /// <summary>
        /// The session where the shot was fired
        /// </summary>
        public Session Session { get; set; }

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

        public int? ResultInteger { get; set; }
        public  bool? ResultIntegerX10 { get; set; }
        public decimal? ResultDecimal { get; set; }

        // Foreign keys

        /// <summary>
        /// /// The identifier of the session that the shot belongs to
        /// </summary>
        public Guid SessionId { get; set; }

        public Shot() { 
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public Shot(ShotDTO shotDTO) : base()
        {
            this.Id = Guid.CreateVersion7();

            if (shotDTO == null)
            {
                throw new ArgumentNullException(nameof(shotDTO));
            }

            if (shotDTO.X == null || shotDTO.Y == null)
            {
                if (shotDTO.R == null || shotDTO.A == null)
                {
                    throw new ArgumentException("X, Y or R, A must have a value");
                }
                else
                {
                    this.R = shotDTO.R.Value;
                    this.A = shotDTO.A.Value;

                    this.X = (decimal)((double)this.R * Math.Cos((double)this.A));
                    this.Y = (decimal)((double)this.R * Math.Sin((double)this.A));
                }
            }
            else
            {
                if (shotDTO.R == null || shotDTO.A == null)
                {
                    this.X = shotDTO.X.Value;
                    this.Y = shotDTO.Y.Value;
                    this.R = (decimal)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y));
                    this.A = (decimal)Math.Atan2((double)this.Y, (double)this.X);
                }
                else
                {
                    throw new ArgumentException("X, Y or R, A must have a value");
                }

            }
        }
    }
}

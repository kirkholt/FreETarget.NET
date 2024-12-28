using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreETarget.NET.Data.Models.DTO
{
    public class ShotDTO
    {
        public Guid TargetId { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public decimal? R { get; set; }
        public decimal? A { get; set; }
    }
}

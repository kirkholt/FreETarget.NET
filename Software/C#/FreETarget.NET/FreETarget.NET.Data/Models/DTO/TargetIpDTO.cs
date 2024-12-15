using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreETarget.NET.Data.Models.DTO
{
    public  class TargetIpDTO
    {
        /// <summary>
        /// Unique identifier of the target
        /// Set in the target hardware
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The local IP address of the target
        /// </summary>
        public string IpAddress { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockerCore.Entities
{
    public class Log:BaseEntity
    {
        public string IpAddress { get; set; } = null!;
        public DateTime Timestamp { get; set; }
        public bool IsBlocked { get; set; }
    }
}

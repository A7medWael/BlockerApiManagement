using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockerCore.DTOS
{
    public class IpRequest
    {
        [Required]
        [RegularExpression(@"^(\d{1,3}\.){3}\d{1,3}$")]
        public string IpAddress { get; set; } = null!;
    }
}

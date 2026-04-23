using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockerCore.DTOS
{
    public class IpResponse
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; } = null!;

        [JsonProperty("country")]
        public string CountryName { get; set; } = null!;
    }
}

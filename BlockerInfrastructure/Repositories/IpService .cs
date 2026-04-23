using BlockerCore.DTOS;
using BlockerCore.InterFaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlockerInfrastructure.Repositories
{
    public class IpService : IIpService
    {
        private readonly HttpClient _httpClient;
        public IpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IpResponse> GetCountryAsync(string ip)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://ip-api.com/json/{ip}");

                if (!response.IsSuccessStatusCode)
                {
                    return new IpResponse
                    {
                        CountryName = "API Limit Reached",
                        CountryCode = "Unknown"
                        
                    };
                }

                var json = await response.Content.ReadAsStringAsync();

                var data= JsonConvert.DeserializeObject<IpResponse>(json);
                return new IpResponse
                {
                    CountryCode = data.CountryCode,
                    CountryName = data.CountryName,
                    
                    
                };
            }
            catch
            {
                return new IpResponse
                {

                    CountryName = "Service Unavailable",
                    CountryCode = "Error"
                };
            }
           
        }

        
    }
}

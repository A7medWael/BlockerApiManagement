using BlockerCore.DTOS;
using BlockerCore.InterFaces;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        public IpService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<IpResponse> GetCountryAsync(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
                throw new ArgumentException("IP is required");

            var baseUrl = _configuration["IpApi:BaseUrl"];

            var response = await _httpClient.GetAsync($"{baseUrl}{ip}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"External API failed: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IpResponse>(json);

        }

        
    }
}

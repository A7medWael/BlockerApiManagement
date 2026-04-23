using BlockerCore.InterFaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpController : ControllerBase
    {
        private readonly IIpService _ipService;
        private readonly IBlockRepository _repo;

        public IpController(IIpService ipService, IBlockRepository repo)
        {
            _ipService = ipService;
            _repo = repo;
        }

        [HttpGet("lookup")]
        public async Task<IActionResult> Lookup(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
                ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            var result = await _ipService.GetCountryAsync(ipAddress);

            return Ok(result);
        }

        [HttpGet("check-block")]
        public async Task<IActionResult> Check()
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

            var result = await _ipService.GetCountryAsync(ip);

            var blocked = _repo.IsBlocked(result.CountryCode);

            return Ok(new
            {
                ip,
                result.CountryCode,
                blocked
            });
        }
    }
}

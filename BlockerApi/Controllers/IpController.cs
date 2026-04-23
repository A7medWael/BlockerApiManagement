using BlockerCore.DTOS;
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

        [HttpPost("lookup")]
        public async Task<IActionResult> Lookup([FromBody] IpRequest request)
        {
            if (string.IsNullOrEmpty(request?.IpAddress))
                return BadRequest("IP is required");

            var result = await _ipService.GetCountryAsync(request?.IpAddress);

            return Ok(result);
        }

        [HttpGet("check-block")]
        public async Task<IActionResult> Check()
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

         
            return Ok(new
            {
                ip,
               status="checked"
            });
        }
    }
}

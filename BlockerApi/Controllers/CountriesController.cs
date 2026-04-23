using BlockerApplication.Services;
using BlockerInfrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly BlockService _blockService;
        public CountriesController(BlockService blockService)
        {
            _blockService = blockService;
        }
        [HttpPost("Block")]
        public IActionResult Block(string CountryCode)
        {
            try
            {
                _blockService.Block(CountryCode);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("block/{code}")]
        public IActionResult Unblock(string CountryCode)
        {
           try {
                _blockService.UnBlock(CountryCode);
                return Ok();
            }
        catch (Exception ex)
        {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("blocked")]
        public IActionResult GetAll(int page = 1, int pageSize = 10, string search = "")
        {
            var result = _blockService.GetAll(page, pageSize, search);
            return Ok(result);
        }
    }

}

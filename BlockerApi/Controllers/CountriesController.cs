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
                return Ok("Blocked Success!");
            }
            catch(Exception ex) 
            {
                return Conflict(ex.Message);
            }
        }
        [HttpDelete("block/{code}")]
        public IActionResult Unblock(string CountryCode)
        {
            try
            {
                _blockService.UnBlock(CountryCode);
                return Ok("Remove Success!");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpGet("blocked")]
        public IActionResult GetAll()
        {
            return Ok(_blockService.GetAll());
        }
    }

}

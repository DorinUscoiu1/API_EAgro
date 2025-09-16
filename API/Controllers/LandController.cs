using API.Services;
using Microsoft.AspNetCore.Mvc;
using API.DTOs;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandController : ControllerBase
    {
        private readonly LandManager landManager;
        public LandController()
        {
            landManager = new LandManager();
        }
        [HttpGet]
        public IActionResult GetLands()
        {
            return Ok(landManager.GetAllLands());
        }

        [HttpGet("{landId}")]
        public IActionResult GetLand(int landId)
        {
            var land = landManager.GetLand(landId);
            if (land != null)
            {
                return Ok(land);
            }
            return NotFound($"land with ID {landId} not found.");
        }


        [HttpPost]
        public IActionResult AddNewLand([FromBody] LandDto landDto)
        {
            try
            {
                landManager.AddLand(landDto);
                return Created();
            }
            catch
            {
                return BadRequest("The request is not valid");
            }
        }

        [HttpPut]
        public IActionResult Updateland([FromBody] LandDto landDto)
        {
            var existingland = landManager.GetLand(landDto.Id);
            if (existingland == null)
            {
                return NotFound($"land with ID {landDto.Id} not found.");
            }

            try
            {
                landManager.UpdateLand(landDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{landId}")]
        public IActionResult Removeland(int landId)
        {
            try
            {
                landManager.RemoveLand(landId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("was-sold-to-owner/{landId}/{farmerId}")]
        public IActionResult WasLandSoldToOwner(int landId, int farmerId)
        {
            bool wasBought = landManager.IsLandBoughtByCurrentOwner(landId, farmerId);
            return Ok(wasBought);
        }

    }
}

using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private readonly FarmerManager farmerManager;

        public FarmerController()
        {
            farmerManager = new FarmerManager();
        }

        [HttpGet]
        public IActionResult GetFarmers()
        {
            return Ok(farmerManager.GetAllFarmers());
        }

        [HttpGet("{farmerId}")]
        public IActionResult GetFarmer(int farmerId)
        {
            var farmer = farmerManager.GetFarmer(farmerId);
            if (farmer == null)
            {
                return NotFound($"The item with id {farmerId} could not be found!");
            }
            return Ok(farmer);
        }
        [HttpPost]
        public IActionResult AddFarmer(FarmerDto farmer)
        {
            try
            {
                farmerManager.AddFarmer(farmer);
                return Created();
            }
            catch
            {
                return BadRequest("This request is not valid!");
            }
        }

        [HttpPut]
        public IActionResult UpdateFarmer([FromBody] FarmerDto user)
        {
            try
            {
                farmerManager.UpdateFarmer(user);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest($"The request is not valid.");
            }
        }
        [HttpDelete("{farmerId}")]
        public IActionResult DeleteFarmer(int farmerId)
        {
            try
            {
                farmerManager.RemoveFarmer(farmerId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest("the request is not valid");
            }

        }
        [HttpGet("{farmerId}/lands")]
        public IActionResult GetUserTickets(int farmerId)
        {
            try
            {
                var tickets = farmerManager.GetFarmerLands(farmerId);
                return Ok(tickets);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{farmerId}/animals")]
        public IActionResult GetFarmerAnimals(int farmerId)
        {
            try
            {
                var tickets = farmerManager.GetFarmerAnimals(farmerId);
                return Ok(tickets);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

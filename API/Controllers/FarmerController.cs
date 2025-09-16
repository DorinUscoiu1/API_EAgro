using API.ApplicationDBContext;
using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
        [HttpGet("{farmerId}/lands")]
        public IActionResult GetFarmerLands(int farmerId, [FromQuery] string location = null, [FromQuery] string county = null, [FromQuery] string type = null)
        {
            try
            {
                var lands = farmerManager.GetFarmerLandsFiltered(farmerId, location, county, type);
                return Ok(lands);
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
        [HttpGet("{farmerId}/otherlands")]
        public IActionResult GetOtherFarmerLands(int farmerId)
        {
            try
            {
                var lands = farmerManager.GetOtherFarmerLands(farmerId);
                return Ok(lands);
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
        [HttpGet("{farmerId}/landsTotalArea")]
        public IActionResult GetFarmerSurface(int farmerId)
        {
            try
            {
                var area = farmerManager.GetTotalArea(farmerId);
                return Ok(area);
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
        [HttpGet("{farmerId}/ratings")]
        public IActionResult GetFarmerRatings(int farmerId)
        {
            try
            {
                var tickets = farmerManager.GetFarmerRatings(farmerId);
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
        [HttpGet("{farmerId}/listings")]
        public IActionResult GetFarmerListings(int farmerId)
        {
            try
            {
                var tickets = farmerManager.GetMarketListingsByFarmer(farmerId);
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
        
        [HttpGet("by-user/{userId}")]
        public IActionResult GetFarmerByUserId(int userId)
        {
            try
            {
                var farmer = farmerManager.GetFarmerByUserId(userId);
                if (farmer == null)
                    return NotFound($"No farmer found for user ID {userId}");
                return Ok(farmer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{farmerId}/funding-request")]
        public IActionResult GetFundingRequestByFarmerId(int farmerId)
        {
            try
            {
                var requestDto = farmerManager.GetFundingRequestByFarmerId(farmerId);

                return Ok(requestDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{farmerId}/animalfunding-request")]
        public IActionResult GetAnimalsFundingRequestByFarmerId(int farmerId)
        {
            try
            {
                var requestDto = farmerManager.GetAnimalFundingRequestByFarmerId(farmerId);

                return Ok(requestDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{farmerId}/supplies")]
        public IActionResult GetFarmerSupplies(int farmerId)
        {
            try
            {
                var supplies = farmerManager.GetFarmerSupplies(farmerId);
                return Ok(supplies);
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

        [HttpPost("{farmerId}/buy-supply")]
        public IActionResult BuySupply(int farmerId, [FromQuery] int supplyId, [FromQuery] int quantity)
        {
            try
            {
                farmerManager.BuySupply(farmerId, supplyId, quantity);
                return Ok("Cumpărare realizată.");
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
    }
}

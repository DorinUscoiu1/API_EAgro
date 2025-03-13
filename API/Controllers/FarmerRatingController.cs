using API.Services;
using Microsoft.AspNetCore.Mvc;
using API.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerRatingController : ControllerBase
    {
        private readonly FarmerRatingManager _farmerRatingManager;

        public FarmerRatingController()
        {
            _farmerRatingManager = new FarmerRatingManager();
        }

        [HttpGet]
        public IActionResult GetFarmerRatings()
        {
            return Ok(_farmerRatingManager.GetAllRatings());
        }

        [HttpGet("{ratingId}")]
        public IActionResult GetFarmerRating(int ratingId)
        {
            try
            {
                var rating = _farmerRatingManager.GetRatingById(ratingId);
                return Ok(rating);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddFarmerRating([FromBody] FarmerRatingDto ratingDto)
        {
            try
            {
                _farmerRatingManager.AddRating(ratingDto);
                return CreatedAtAction(nameof(GetFarmerRating), new { ratingId = ratingDto.Id }, ratingDto);
            }
            catch
            {
                return BadRequest("Invalid request");
            }
        }

        [HttpPut]
        public IActionResult UpdateFarmerRating([FromBody] FarmerRatingDto ratingDto)
        {
            try
            {
                _farmerRatingManager.UpdateRating(ratingDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{ratingId}")]
        public IActionResult RemoveFarmerRating(int ratingId)
        {
            try
            {
                _farmerRatingManager.RemoveRating(ratingId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

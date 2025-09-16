using API.Services;
using Microsoft.AspNetCore.Mvc;
using API.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalManager _animalManager;

        public AnimalController()
        {
            _animalManager = new AnimalManager();
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(_animalManager.GetAllAnimals());
        }

        [HttpGet("{animalId}")]
        public IActionResult GetAnimal(int animalId)
        {
            try
            {
                var animal = _animalManager.GetAnimal(animalId);
                return Ok(animal);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddAnimal([FromBody] AnimalDto animalDto)
        {
            try
            {
                _animalManager.AddAnimal(animalDto);
                return CreatedAtAction(nameof(GetAnimal), new { animalId = animalDto.Id }, animalDto);
            }
            catch
            {
                return BadRequest("Invalid request");
            }
        }

        [HttpPut]
        public IActionResult UpdateAnimal([FromBody] AnimalDto animalDto)
        {
            try
            {
                _animalManager.UpdateAnimal(animalDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{animalId}")]
        public IActionResult RemoveAnimal(int animalId)
        {
            try
            {
                _animalManager.RemoveAnimal(animalId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        //[HttpGet("{animaldId}/supplies")]
        //public IActionResult GetAnimalSupplies(int animalId)
        //{
        //    try
        //    {
        //        var tickets = _animalManager.GetAnimalSupplies(animalId);
        //        return Ok(tickets);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}
    }
}

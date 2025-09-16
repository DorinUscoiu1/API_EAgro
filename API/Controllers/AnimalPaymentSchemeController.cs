using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalPaymentSchemeController : ControllerBase
    {
        private readonly AnimalPaymentSchemeManager _manager = new AnimalPaymentSchemeManager();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_manager.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var scheme = _manager.GetById(id);
            if (scheme == null) return NotFound();
            return Ok(scheme);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AnimalPaymentSchemeDto dto)
        {
            try
            {
                _manager.Create(dto);
                return Created("", dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AnimalPaymentSchemeDto dto)
        {
            try
            {
                var updated = _manager.Update(id, dto);
                if (!updated) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var deleted = _manager.Delete(id);
                if (!deleted) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

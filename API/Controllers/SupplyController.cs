using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_LICENTA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyController : ControllerBase
    {
        private readonly SupplyManager _supplyManager;

        public SupplyController()
        {
            _supplyManager = new SupplyManager();
        }
        [HttpGet]
        public IActionResult GetSupplies()
        {
            return Ok(_supplyManager.GetAllSupplies());
        }

        [HttpGet("{supplyId}")]
        public IActionResult GetSupply(int supplyId)
        {
            try
            {
                var supply = _supplyManager.GetSupply(supplyId);
                return Ok(supply);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddSupply([FromBody] SupplyDto supplyDto)
        {
            try
            {
                _supplyManager.AddSupply(supplyDto);
                return Created();
            }
            catch
            {
                return BadRequest("The request is not valid");
            }
        }

        [HttpPut]
        public IActionResult UpdateSupply([FromBody] SupplyDto supplyDto)
        {
            try
            {
                _supplyManager.UpdateSupply(supplyDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{supplyId}")]
        public IActionResult DeleteSupply(int supplyId)
        {
            try
            {
                _supplyManager.DeleteSupply(supplyId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

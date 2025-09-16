using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly MarketItemManager _marketManager = new MarketItemManager();

        [HttpGet]
        public IActionResult GetAllMarketItems()
        {
            return Ok(_marketManager.GetAllMarketItems());
        }
        [HttpGet("{id}")]
        public IActionResult GetMarketItemById(int id)
        {
            var item = _marketManager.GetMarketItemById(id);
            if (item == null) return NotFound("Item not found");
            return Ok(item);
        }
        [HttpPost("buy/{id}")]
        public IActionResult BuyMarketItem(int id, [FromBody] int buyerFarmerId)
        {
            try
            {
                _marketManager.MarkItemAsSoldToBuyer(id, buyerFarmerId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("farmer/{farmerId}")]
        public IActionResult GetMarketItemsByFarmer(int farmerId)
        {
            return Ok(_marketManager.GetMarketItemsByFarmer(farmerId));
        }

        [HttpPost("sell")]
        public IActionResult PostMarketItem([FromBody] MarketItemDto marketItemDto)
        {
            try
            {
                _marketManager.AddMarketItem(marketItemDto);
                return Created("", marketItemDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/mark-sold")]
        public IActionResult MarkItemAsSold(int id)
        {
            try
            {
                _marketManager.MarkItemAsSold(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMarketItem(int id)
        {
            try
            {
                _marketManager.DeleteMarketItem(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
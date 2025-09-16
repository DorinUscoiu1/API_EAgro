using API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LandFundingRequestController : ControllerBase
    {
        private readonly LandFundingRequestManager _manager;

        public LandFundingRequestController()
        {
            _manager = new LandFundingRequestManager();
        }
        [HttpGet]
        public IActionResult GetAllRequests()
        {
            try
            {
                var requests = _manager.GetAllRequests();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("create")]
        public IActionResult CreateRequest(int farmerId, [FromBody] List<int> landIds)
        {
            try
            {
                var request = _manager.CreateRequest(farmerId, landIds);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{requestId}/lands")]
        public IActionResult GetLandsForRequest(int requestId)
        {
            try
            {
                var lands = _manager.GetLandsByRequestId(requestId);
                return Ok(lands);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{requestId}/status")]
        public IActionResult UpdateStatus(int requestId, [FromQuery] string status, [FromQuery] string comment)
        {
            try
            {
                _manager.UpdateStatus(requestId, status, comment);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{requestId}")]
        public IActionResult DeleteRequest(int requestId)
        {
            try
            {
                _manager.DeleteRequest(requestId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

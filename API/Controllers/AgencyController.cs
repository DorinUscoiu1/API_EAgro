using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        private readonly AgencyManager agencyManager;
        public AgencyController()
        {
            agencyManager = new AgencyManager();
        }

        [HttpGet]
        public IActionResult GetAllAgencies()
        {
            return Ok(agencyManager.GetAllAgencies());
        }
        [HttpGet("{agencyId}")]
        public IActionResult GetAgency(int agencyId)
        {
            var agency=agencyManager.GetAgency(agencyId);
            if (agency == null) { return NotFound($"Agency with ID {agencyId} not found!"); }
            return Ok(agency);
        }

        [HttpPost]
        public IActionResult AddAgency([FromBody]AgencyDto agencyDto)
        {
            try
            {
                agencyManager.AddAgency(agencyDto);
                return Created();
            }
            catch
            {
                return BadRequest("The request is not valid!");
            }
        }
        [HttpPut]
        public IActionResult UpdateAgency([FromBody] AgencyDto agency)
        {
            try
            {
                agencyManager.UpdateAgency(agency);
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
        [HttpDelete("{agencyId}")]
        public IActionResult DeleteAgency(int agencyId)
        {
            try
            {
                agencyManager.RemoveAgency(agencyId);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{agencyId}/agents")]
        public IActionResult GetAgencyAgents(int agencyId)
        {
            try
            {
                var agents = agencyManager.GetAgencyAgents(agencyId);
                return Ok(agents);
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

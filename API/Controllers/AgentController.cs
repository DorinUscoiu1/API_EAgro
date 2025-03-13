using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly AgentManager agentManager;
        public AgentController()
        {
            agentManager = new AgentManager();
        }
        [HttpGet]
        public IActionResult GetAgents()
        {
            return Ok(agentManager.GetAllAgents());
        }
        [HttpGet("{agentId}")]
        public IActionResult GetAgent(int agentId)
        {
            var agent = agentManager.GetAgent(agentId);
            if (agent == null)
            {

                return NotFound($"Agent with ID {agentId} not found.");
            }
            return Ok(agent);
        }
        [HttpPost]
        public IActionResult AddNewAgent([FromBody] AgentDto agentDto)
        {
            try
            {
                agentManager.AddAgent(agentDto);
                return Created();
            }
            catch
            {
                return BadRequest("The request is not valid!");
            }
        }
        [HttpPut]
        public IActionResult UpdateAgent([FromBody] AgentDto agentDto)
        {
            var agent = agentManager.GetAgent(agentDto.Id);
            if (agent == null)
            {
                return NotFound($"Agent with ID {agentDto.Id} does not exist");
            }
            try
            {
                agentManager.UpdateAgent(agentDto);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{agentId}")]
        public IActionResult RemoveAgent(int agentId)
        {
            try
            {
                agentManager.DeleteAgent(agentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("{agentId}/farmers")]
        public IActionResult GetAnimalSupplies(int agentId)
        {
            try
            {
                var farmers = agentManager.GetAgentFarmers(agentId);
                return Ok(farmers);
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

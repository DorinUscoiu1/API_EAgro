using API.ApplicationDBContext;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using API.DTOs;
using API.Models;
namespace API.Services
{
    public class AgentManager
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly IMapper _mapper;

        public AgentManager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();
        }
        public List<AgentDto> GetAllAgents()
        {
            var agents = _context.Agents.ToList();
            return _mapper.Map<List<AgentDto>>(agents);
        }
        public AgentDto GetAgent(int agentId)
        {
            var agent = _context.Agents.FirstOrDefault(a => a.Id == agentId);
            return _mapper.Map<AgentDto>(agent);
        }

        public void AddAgent(AgentDto agentDto)
        {
            var agent = _mapper.Map<Agent>(agentDto);
            _context.Agents.Add(agent);
            _context.SaveChanges();
        }

        public void UpdateAgent(AgentDto agentDto)
        {
            var agent = _context.Agents.FirstOrDefault(a => a.Id == agentDto.Id);
            if (agent != null)
            {
                _mapper.Map(agentDto, agent);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Agent not found");
            }
        }
        public void DeleteAgent(int agentId)
        {
            var agent = _context.Agents.FirstOrDefault(a => a.Id == agentId);
            if (agent != null)
            {
                _context.Agents.Remove(agent);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Agent not found");
            }
        }
        public List<FarmerDto> GetAgentFarmers(int agentId)
        {
            var agent = _context.Agents
                .Include(f => f.Farmers)
                .FirstOrDefault(f => f.Id == agentId);

            if (agent == null)
            {
                throw new Exception("Farmer not found!");
            }

            return _mapper.Map<List<FarmerDto>>(agent.Farmers);
        }
    }
}

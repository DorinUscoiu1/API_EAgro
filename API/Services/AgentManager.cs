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
            var agents = _context.Agents.Include(a => a.User).ToList();
            return _mapper.Map<List<AgentDto>>(agents);
        }
        public AgentDto GetAgent(int agentId)
        {
            var agent = _context.Agents
                .Include(a => a.User).FirstOrDefault(a => a.Id == agentId);
            return _mapper.Map<AgentDto>(agent);
        }

        public void AddAgent(AgentDto agentDto)
        {
            var user = new User
            {
                Name = agentDto.Name,
                Email= agentDto.Email,
                Password = "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824",
                Phone = agentDto.Phone,
                Role = "Agent"
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            var agent = new Agent
            {
                Name = agentDto.Name,
                Email = agentDto.Email,
                AgencyId = agentDto.AgencyId,
                UserId = user.Id
            };

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
            var agent = _context.Agents.Include(a => a.User).FirstOrDefault(a => a.Id == agentId);
            if (agent != null)
            {
                var user = agent.User;

                _context.Agents.Remove(agent);

                if (user != null)
                {
                    _context.Users.Remove(user);
                }

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
                .Include(f => f.Farmers).ThenInclude(f=>f.User)
                .FirstOrDefault(f => f.Id == agentId);

            if (agent == null)
            {
                throw new Exception("Farmer not found!");
            }

            return _mapper.Map<List<FarmerDto>>(agent.Farmers);
        }
        public AgentDto GetAgentByUserId(int userId)
        {
            var farmer = _context.Agents.Include(f => f.User).FirstOrDefault(f => f.UserId == userId);
            if (farmer == null)
                return null;
            return _mapper.Map<AgentDto>(farmer);
        }
        public List<FarmerDto> SearchAgentFarmersByName(int agentId, string name)
        {
            var agent = _context.Agents.FirstOrDefault(a => a.Id == agentId);
            if (agent == null)
                throw new ArgumentException("Agent not found");

            var farmers = _context.Farmers
                .Include(f => f.User) 
                .Where(f => f.AgentId == agentId && f.Name.Contains(name))
                .ToList();

            return _mapper.Map<List<FarmerDto>>(farmers);
        }


    }
}

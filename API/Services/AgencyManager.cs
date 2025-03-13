using API.ApplicationDBContext;
using API.Models;
using API.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AgencyManager
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly IMapper _mapper;

        public AgencyManager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();
        }
        public List<AgencyDto>GetAllAgencies()
        {
           var agencies= _context.Agencies.ToList();
            return _mapper.Map<List<AgencyDto>>(agencies);
        }
        public AgencyDto GetAgency(int agencyId)
        {
            var agency= _context.Agencies.FirstOrDefault(a=>a.Id==agencyId);
            return _mapper.Map<AgencyDto>(agency);
        }
        public void AddAgency(AgencyDto agencyDto)
        {
            var agency=_mapper.Map<Agency>(agencyDto);
            _context.Agencies.Add(agency);
            _context.SaveChanges();
        }
        public void UpdateAgency(AgencyDto agencyDto)
        {
            var agency=_context.Agencies.FirstOrDefault(a=>a.Id == agencyDto.Id);
            if (agency == null) throw new Exception("Agency not found!");
            _mapper.Map(agencyDto,agency);
            _context.SaveChanges();
        }
        public void RemoveAgency(int agencyId)
        {
            var agency=_context.Agencies.FirstOrDefault(a=> a.Id==agencyId);
            if (agency == null) throw new Exception("Agency not found!");
            _context.Agencies.Remove(agency);
            _context.SaveChanges();
        }
        public List<AgentDto> GetAgencyAgents(int agencyId)
        {
            var agency = _context.Agencies
                .Include(f => f.Agents)
                .FirstOrDefault(f => f.Id == agencyId);

            if (agency == null)
            {
                throw new Exception("Farmer not found!");
            }

            return _mapper.Map<List<AgentDto>>(agency.Agents);
        }
    }
}

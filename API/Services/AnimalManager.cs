using API.DTOs;
using API.Models;
using API.ApplicationDBContext;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace API.Services
{
    public class AnimalManager
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly IMapper _mapper;

        public AnimalManager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();
        }

        public List<AnimalDto> GetAllAnimals()
        {
            var animals = _context.Animals.ToList();
            return _mapper.Map<List<AnimalDto>>(animals);
        }

        public AnimalDto GetAnimal(int aircraftId)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.Id == aircraftId);
            return _mapper.Map<AnimalDto>(animal);
        }

        public void AddAnimal(AnimalDto aircraftDto)
        {
            var aircraft = _mapper.Map<Animal>(aircraftDto);
            _context.Animals.Add(aircraft);
            _context.SaveChanges();
        }
        public void UpdateAnimal(AnimalDto animalDto)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.Id == animalDto.Id);
            if (animal != null)
            {
                _mapper.Map(animalDto, animal);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Animal not found");
            }
        }

        public void RemoveAnimal(int animalId)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.Id == animalId);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Animal not found");
            }
        }
        //public List<AnimalSupplyDto> GetAnimalSupplies(int animalId)
        //{
        //    var animal = _context.Animals
        //        .Include(a => a.AnimalSupplies) // include tabela de legătură
        //            .ThenInclude(asup => asup.Supply) // apoi include supply-ul din legătură
        //        .FirstOrDefault(a => a.Id == animalId);

        //    if (animal == null)
        //    {
        //        throw new Exception("Animal not found!");
        //    }

        //    // Mapăm fiecare AnimalSupply în DTO cu supply + quantity
        //    return _mapper.Map<List<AnimalSupplyDto>>(animal.AnimalSupplies);
        //}

    }
}
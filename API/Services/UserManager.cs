using API.ApplicationDBContext;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class UserManager
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly IMapper _mapper;

        public UserManager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();
        }
        public List<UserDto> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return _mapper.Map<List<UserDto>>(users);
        }
        public UserDto GetUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(a => a.Id == userId);
            return _mapper.Map<UserDto>(user);
        }

        public void AddUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(UserDto userDto)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userDto.Id);
            if (user == null)
                throw new ArgumentException("User doesn't exist.");

            if (userDto.Password == null || userDto.Password.IsNullOrEmpty())
                userDto.Password = user.Password;

            _mapper.Map(userDto, user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(a => a.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("User not found");
            }
        }
        public UserDto Login(LoginDto loginDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == loginDto.EmailAddress);
            if (user == null)
            {
                throw new ArgumentException("User does not exist");
            }
            if (user.Password != loginDto.Password)
            {
                throw new ArgumentException("Incorrect password");
            }
            return _mapper.Map<UserDto>(user);
        }

        public UserDto Register(UserDto userDto)
        {

            if (_context.Users.Any(u => u.Email == userDto.Email))
                throw new ArgumentException("A user with the same email address already exists");

            var user = _mapper.Map<User>(userDto);
            _context.Users.Add(user);
            _context.SaveChanges();
            return _mapper.Map<UserDto>(user);
        }
    }
}

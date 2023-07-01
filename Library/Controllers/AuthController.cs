using Library.DbModels.FluentModels;
using Library.Dtos;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController :ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        private readonly LibraryContext _context;

        public AuthController(IAuthService authService, IConfiguration config, LibraryContext context)
        {
            _authService = authService;
            _config = config;
            _context = context;
        }

        
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _authService.UserExists(userForRegisterDto.Username))
                return BadRequest("Username already exists");

            //var userToCreate = _mapper.Map<User>(userForRegisterDto);
            Fluent_Reader fluent_Reader = new()
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PhoneNumber = userForRegisterDto.PhoneNumber
            };

            Fluent_User userToCreate = new()
            {
                Reader = fluent_Reader,
                Username = userForRegisterDto.Username,
                Email = userForRegisterDto.Email,
                Created = DateTime.Now
            };


            var createdUser = await _authService.Register(userToCreate, userForRegisterDto.Password);

            //var userToReturn = _mapper.Map<UserForDetailedDto>(createdUser);


            //return CreatedAtRoute("GetUser", new
            //{
            //    controller = "Users",
            //    id = createdUser.Id
            //}, createdUser);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _authService.Login(userForLoginDto.Username
                .ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                //Expires = DateTime.Now.AddDays(1), 
                Expires = DateTime.Now.AddMinutes(20), 
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            //var user = _mapper.Map<UserForListDto>(userFromRepo);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                userFromRepo
            });
        }

        [Authorize]
        [HttpGet("GetUserById")]
        public async Task<ActionResult<Fluent_User>> GetUserById(int id)
        {
            return await _context.Fluent_Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<Fluent_User>>> GetAllUsers()
        {
           return await _context.Fluent_Users.ToListAsync();
        }


    }
}

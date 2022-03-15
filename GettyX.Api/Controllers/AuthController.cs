using AutoMapper;
using Getty.Core.DTOs;
using Getty.Core.Entities;
using Getty.Core.Helpers;
using Getty.Core.Interfaces;
using GettyX.Api.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GettyX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyCors")]
    public class AuthController : ControllerBase
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration; 


        public AuthController(IUsersRepository userService,
                               IMapper mapper,
                               IConfiguration configuration)
        {
            _userRepository = userService;
            _mapper = mapper;   
            _configuration = configuration; 
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserLoginDTO>> Register (UsrUserDTO request)
        {
            //Creating has for the password
            PasswordHasher.CreatePassword(request.UsrPassword, out byte[] passwordHash, out byte[] passwordSalt);
            
            var _user = _mapper.Map<UsrUser>(request);
            _user.UsrPassword = passwordHash;
            _user.UsrSalt = passwordSalt;
            await _userRepository.RegisterUser(_user);

            request = _mapper.Map<UsrUserDTO>(_user);

            var response = new ApiResponse<UsrUserDTO>(request);

            return Ok(response);


        }




        //Just for verification, this should be in a service
        [HttpGet , Authorize ]
        public  ActionResult<UserIdentityDTO> GetMe()
        {
            var userName =  User?.Identity?.Name;

            var roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);

            var EmpID = ((ClaimsIdentity)User.Identity).Claims
                        .Where(c=> c.Type == ClaimTypes.Dns)
                        .Select(c => c.Value)
                        .First();

            var userInfo = new UserIdentityDTO()
            {
                UserName = userName,
                Roles = roles.ToList(),
                EmpID = EmpID
            };

            var response = new ApiResponse<UserIdentityDTO>(userInfo);
            return Ok(response);

        }
      
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginDTO request)
        {
            var isValid = await _userRepository.VerifyUser(request.UsrUsername, request.UsrPassword);


            if (isValid){

                string token =  GenerateToken(request.UsrUsername);
                return Ok(token);
            }
            return BadRequest("Invalid Credentials");

        }

        private string GenerateToken(string username)
        {
            //Header
            var symmetricsecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricsecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);



            //claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };


            //Get Roles
            var _userRoles = _userRepository.GetUserRoles(username);

            var EmpID = _userRepository.GetEmpID(username);

            claims.Add(new Claim(ClaimTypes.Dns, EmpID.ToString()));

            foreach (var UserRole in _userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, UserRole));
            }

            //payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(18)
            );

            //crear token
            var token = new JwtSecurityToken(header, payload);



            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

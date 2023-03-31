using Customer.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User.Microservices.Application.DTOs;
using User.Microservices.Application.UnitOfWork;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IUnitOfWork uow;
        public AccountController(IUnitOfWork uow, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.uow = uow;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(loginReqDto loginReq)
        {
            var Customers = await uow.CustomersRepository.Login(loginReq.UserName, loginReq.Password);
            if (Customers == null) { return Unauthorized(); }


            var loginRes = new loginResDto();
            loginRes.UserName = Customers.UserName;
            loginRes.Token = CreateJWT(Customers);
            return Ok(Customers);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(loginReqDto loginReq)
        {
            uow.CustomersRepository.Register(loginReq.UserName, loginReq.Password);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        private string CreateJWT(Customers customers)
        {
            var secretKey = configuration.GetSection("AppSettings:key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var clasims = new Claim[]
            {
                new Claim(ClaimTypes.Name,customers.UserName),new Claim(ClaimTypes.NameIdentifier,customers.ID.ToString())
            };
            var SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(clasims),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = SigningCredentials
            };
            var TokenHandler = new JwtSecurityTokenHandler();
            var token = TokenHandler.CreateToken(tokenDescriptor);
            return TokenHandler.WriteToken(token);

        }
    }
}

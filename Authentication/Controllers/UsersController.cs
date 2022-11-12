using Authentication.Data.Models;
using Authentication.DTOs.Users.Login;
using Authentication.DTOs.Users.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<Employee> userManager;

        public UsersController(IConfiguration configuration,UserManager<Employee> _userManager)
        {
            this.configuration = configuration;
            this.userManager = _userManager;
        }
        [HttpPost]//method is post, to send the Crednetials in the body(POST method) which is more secure than sending
                  //the data in the URL(GET method)

        [Route("static-login")]
        public ActionResult<TokenDTO> StaticLogin(LoginCredentials input)//input: login ,output:Jwt Token
                                                                         //hashing result +claim+key
        {
            if (input.UserName != "admin" || input.Password != "password")
            {
                return Unauthorized();
            }

            // Generating Claims

            var userClaims = new List<Claim>
            {
                new Claim("Name", "Ahmed"),//Customized
                new Claim("Nationality", "Egyptian"),
                new Claim(ClaimTypes.GivenName, input.UserName),//built in types
            };

            //Getting SecertKey
            var KeyFromConfig = configuration.GetValue<string>("SecretKey");//get the value from Json file

            var KeyInBytes= Encoding.ASCII.GetBytes(KeyFromConfig);
            var SecretKey = new SymmetricSecurityKey(KeyInBytes);

            //choosing HashingAlgorithm

            var signingCredentials = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256Signature);

            //creating token

            var JWT = new JwtSecurityToken(
                claims: userClaims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMinutes(15),
                notBefore: DateTime.Now //when to use it

                );

            var tokenhandler = new JwtSecurityTokenHandler();

            return new TokenDTO
            {
                Token = tokenhandler.WriteToken(JWT) //string 

            };

        }

        #region Register

        [HttpPost]
        [Route("register")]
        
        public async Task<ActionResult> Register (RegisterCrednetials input)
        {

            var employee = new Employee()
            {
                UserName = input.Username,
                Email=input.Email,
                Department=input.Department
                
            };
            //to Hash Password and save to DB 
             var result = await   userManager.CreateAsync(employee, input.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,employee.Id),
                new Claim(ClaimTypes.Role,"Manager")
            };

            await userManager.AddClaimsAsync(employee, claims);//adding claim to the user

            return NoContent();

        }
        #endregion



        #region KeyLogin
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDTO>> Login(LoginCredentials input)
        {
            var employee = await userManager.FindByNameAsync(input.UserName);
            if(employee == null)
            {

                return BadRequest(new { message = "user not found" });
            }
            var Islocked= await userManager.IsLockedOutAsync(employee);
            if (Islocked)
            {
                return BadRequest(new { message = "You  are Locked Out" });
            }

            bool passwardCheckResult = await userManager.CheckPasswordAsync(employee, input.Password);

            if (!passwardCheckResult)
            {
                await userManager.AccessFailedAsync(employee);//increase number of failed Attempts
                return Unauthorized();
            }

            var userClaims = await userManager.GetClaimsAsync(employee);

            //Getting SecertKey
            var KeyFromConfig = configuration.GetValue<string>("SecretKey");//get the value from Json file

            var KeyInBytes = Encoding.ASCII.GetBytes(KeyFromConfig);
            var SecretKey = new SymmetricSecurityKey(KeyInBytes);

            //choosing HashingAlgorithm

            var signingCredentials = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256Signature);

            //creating token

            var JWT = new JwtSecurityToken(
                claims: userClaims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMinutes(15),
                notBefore: DateTime.Now //when to use it

                );

            var tokenhandler = new JwtSecurityTokenHandler();

            return new TokenDTO
            {
                Token = tokenhandler.WriteToken(JWT) //string 

            };

        }


        #endregion

    }
}

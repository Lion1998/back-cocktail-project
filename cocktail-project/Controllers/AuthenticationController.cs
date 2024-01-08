using cocktail_project.Contexts;
using cocktail_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace cocktail_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthenticationController : ControllerBase
    {
        private IConfiguration myConfing;
        private AuthenticationContexts dbContext;
        public AuthenticationController(IConfiguration confinguration)
        {
            myConfing = confinguration;
            dbContext = new AuthenticationContexts();
        }
        [HttpPost]
        public ActionResult Authenticate(Authentication userAuthentication)
        {
            var user = AuthenticateUser(userAuthentication);
            if (user == null)
            {
                return Unauthorized();
            }
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(myConfing["Authentication:SecretForKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim("given_name",""+user.FirstName),
                new Claim("famliy_name",""+user.LastName),
                new Claim ("sub",user.ID.ToString()),
                new Claim ("rol",""+user.Type)
            };

            var token = new JwtSecurityToken
                (
                myConfing["Authentication:Issuer"],
                myConfing["Authentication:Audience"],
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(10),
                creds
                );
            var result = new JwtSecurityTokenHandler().WriteToken(token);
            var response = new
            {
                token = result,
                user = user
            };
            return Ok(response);
        }

        private Authentication AuthenticateUser(Authentication auth)
        {
            return AuthenticateUser(auth.Email, auth.Password);
        }

        private Authentication AuthenticateUser(string email, string password)
        {
            Authentication authUser = dbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return authUser;
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using cocktail_project.Models;
using Microsoft.EntityFrameworkCore;
using cocktail_project.Contexts;

namespace cocktail_project.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class LoginController : ControllerBase
    {
        private LoginContexts dbContext;
        private readonly ILogger _logger;
        public LoginController(ILogger<LoginController> logger)
        {
            dbContext = new LoginContexts();
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Login> InsertUser(string email,string password)
        {
            try
            {
                Login User = dbContext.Users.FirstOrDefault((u => u.Email == email && u.Password == password));
            if (User == null)
            {
                return NotFound();
            }
                _logger.LogInformation("User " + email + " is logged in");
                return Ok(User);
            }catch (Exception ex)
            {
                    _logger.LogInformation($" Failed to insert user: {email}");
                    return StatusCode(500,"Sorry, we ran into an ussye, try again later");
            }
        }
            

    };
};

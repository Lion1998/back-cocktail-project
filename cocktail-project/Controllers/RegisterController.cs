using Microsoft.AspNetCore.Mvc;
using cocktail_project.Models;
using cocktail_project.Contexts;
using Microsoft.EntityFrameworkCore;

namespace cocktail_project.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RegisterController : ControllerBase 
    {
        private RegisterContexts dbContext;
        public RegisterController()
        {
            dbContext = new RegisterContexts();
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<Register> users;
           
                users = dbContext.Users.ToList();
                return Ok(users);
            
        }
        [HttpPost]
        public ActionResult InsertUser(Register newUser)
        {
            dbContext.Users.Add(newUser);
             dbContext.SaveChanges();
            return CreatedAtAction(
                                     "Get",
                                     new { id = newUser.ID },
                                     newUser
                );
        }

    }
}

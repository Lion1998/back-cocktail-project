using Azure;
using cocktail_project.Contexts;
using cocktail_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace cocktail_project.Controllers
{
    [ApiController]
    public class PatchController : ControllerBase
    {
        private OrderContexts dbContext;
        private readonly ILogger _logger;
        public PatchController(ILogger<PatchController> logger)
        {
            dbContext = new OrderContexts();
            _logger = logger;
        }
        [HttpPatch("{id}")]
        public ActionResult PatchUser(int id, JsonPatchDocument<Orders> patchDocument)
        {
            Orders userTopatch = dbContext.Booking.FirstOrDefault(u => u.ID == id);
            if (userTopatch == null)
            {
                return NotFound();
            }
            patchDocument.ApplyTo(userTopatch ,ModelState);
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(userTopatch))
            {
                return BadRequest(ModelState);
            }
            dbContext.SaveChanges();
            _logger.LogInformation($"Oreder {id} is get changes ");
            return NoContent();
        }
    }
}

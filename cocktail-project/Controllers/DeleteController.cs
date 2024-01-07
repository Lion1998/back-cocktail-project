using Microsoft.AspNetCore.Mvc;
using cocktail_project.Models;
using cocktail_project.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace cocktail_project.Controllers
{
    [ApiController]
    [Authorize(Policy = "TypeMustAdmin")]
    [Route("[Controller]")]
    public class DeleteController : ControllerBase
    {
        private LoginContexts dbContextLogin;
        private OrderContexts dbContextOrder;
        private readonly ILogger _logger;

        public DeleteController(ILogger<DeleteController> logger)
        {
            dbContextOrder = new OrderContexts();
            dbContextLogin = new LoginContexts();
            _logger = logger;
            }
        [HttpDelete("DeleteUser/{id}")]
        public ActionResult<Login> DeleteUser(int id)
        {
            try
            {
                Login user = dbContextLogin.Users.Find(id);

                if (user == null)
                {
                    return NotFound();
                }

                dbContextLogin.Users.Remove(user);
                dbContextLogin.SaveChanges();

              _logger.LogInformation($"ID {id} has been deleted successfully.");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete user with ID: {id}");
                return StatusCode(500, "Sorry, we ran into an issue. Please try again later.");
            }
        }

        [HttpDelete("DeleteOrder/{id}")]
        public ActionResult<Orders> DeleteOrder(int id)
        {
            try
            {
                Orders order = dbContextOrder.Booking.Find(id);

                if (order == null)
                {
                    return NotFound();
                }

                dbContextOrder.Booking.Remove(order);
                dbContextOrder.SaveChanges();
                _logger.LogInformation($"Order {id} has been deleted successfully.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete order: {id}");
                return StatusCode(500, "Sorry, we ran into an issue. Please try again later.");
            }
        }


    }
}

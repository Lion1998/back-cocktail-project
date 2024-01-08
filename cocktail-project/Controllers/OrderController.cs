using cocktail_project.Contexts;
using cocktail_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace cocktail_project.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrderController : Controller
    {

        private OrderContexts dbContextOrderContexts;
        private ArrivalTimeContexts dbContextArrivalTime;
        public OrderController()
        {
            dbContextOrderContexts = new OrderContexts();
            dbContextArrivalTime = new ArrivalTimeContexts();
        }

        [HttpGet("Orders")]
        public ActionResult OrderViewing()
        {
            List<Orders> orders;

            orders = dbContextOrderContexts.Booking.ToList();
            return Ok(orders);
        }
        [HttpPost]
        public ActionResult InsertOrders([FromBody] Orders newOrder)
        {
            if (newOrder == null)
            {
                return BadRequest("Invalid JSON");
            }

            dbContextOrderContexts.Booking.Add(newOrder);
            dbContextOrderContexts.SaveChanges();

            return Ok();
        }
        [HttpGet("AriivalTime")]
        public ActionResult TimeViewing()
        {
            List< ExpectedArrival > time;

            time = dbContextArrivalTime.ExpectedArrival.ToList();
            return Ok(time);
        }


    }
}

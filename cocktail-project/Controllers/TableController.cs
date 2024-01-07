using cocktail_project.Contexts;
using cocktail_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace cocktail_project.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TableController : ControllerBase
    {
        private TableContexts dbContext;
        public TableController()
        {
            dbContext = new TableContexts();
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<Table> table;

            table = dbContext.Tables.ToList();
            return Ok(table);

        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace cocktail_project.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ExpectedArrivalID { get; set; }
        public int TablesID { get; set; }
        public DateTime Date { get; set; }
        
       

    }
}

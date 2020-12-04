using System.Collections.Generic;

namespace CustomerPortal.Models
{
    public class Column
    {
        public int id { get; set; }
        public string status { get; set; }
        public string type_building { get; set; }
        public int amount_floors_served { get; set; }
        public List<Elevator> elevators { get; set; }

        public Battery Battery { get; set; }
    }
}
using System.Collections.Generic;

namespace CustomerPortal.Models
{
    public class Battery
    {
        public int id { get; set; }
        public List<Column> columns { get; set; }

        //public Building Building { get; set; }
    }
}
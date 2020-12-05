using System.Collections.Generic;

namespace CustomerPortal.Models
{
    public class Battery
    {
        public int id { get; set; }
        public string cert_ope { get; set; }
        public string information { get; set; }
        public int building_id { get; set; }
        public string status { get; set; }
        public List<Column> columns { get; set; }
    }
}
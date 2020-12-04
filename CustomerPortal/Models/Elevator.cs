namespace CustomerPortal.Models
{
    public class Elevator
    {
        public int id { get; set; }
        public int column_id { get; set; }
        public string status { get; set; }
        public string serial_number { get; set; }
        public string model { get; set; }
        public string type_building { get; set; }

        public Column Column { get; set; }
    }
}
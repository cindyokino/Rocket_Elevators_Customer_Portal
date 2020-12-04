using System.Collections.Generic;

namespace CustomerPortal.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string company_name { get; set; }
        public string cpy_contact_name { get; set; }
        public string cpy_contact_phone { get; set; }
        public string cpy_contact_email { get; set; }
        public string cpy_description { get; set; }
        public string sta_name { get; set; } // Support name
        public string sta_phone { get; set; } // Support phone
        public string sta_mail { get; set; } // Support email
        public List<Building> buildings { get; set; }
    }
}
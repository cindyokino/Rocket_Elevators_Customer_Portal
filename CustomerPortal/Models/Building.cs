using System.Collections.Generic;

namespace CustomerPortal.Models
{
    public class Building
    {
        public int id { get; set; }
        public string adm_contact_name { get; set; }
        public string adm_contact_mail { get; set; }
        public string adm_contact_phone { get; set; }
        public string tect_contact_name { get; set; }
        public string tect_contact_email { get; set; }
        public string tect_contact_phone { get; set; }
        public int customer_id { get; set; }
        public string address_id { get; set; }
        public List<Battery> batteries { get; set; }
        //public Customer customer { get; set; }
    }
}
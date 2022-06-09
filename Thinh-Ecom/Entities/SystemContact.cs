using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thinh_Ecom.Entities
{
    public class SystemContact
    {
        public int Contact_Id { set; get; }
        public string Contact_Address { set; get; }
        public string Contact_Phone { set; get; }
        public string Contact_Email { set; get; }
        public string Contact_Website { set; get; }

        //user
        public string Contact_AppUserFK { set; get; }
        public AppUser AppUser { get; set; }
    }
}

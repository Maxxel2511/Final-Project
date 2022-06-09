using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Thinh_Ecom.Entities
{
    public class AppUser :IdentityUser
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime DoB { set; get; }
        public string user_Country { set; get; }
        public string user_CompanyName { set; get; }
        public string user_City { set; get; }
        public string user_State { set; get; }
        public string user_PostalCode { set; get; }
        public string user_PhoneNumber { set; get; }
        public string user_Address1 { set; get; }
        public string user_Address2 { set; get; }
        public List<Bills> BillsAU { get; set; }
        public List<Cart> CartU { get; set; }
        public List<About> AboutU { get; set; }

        public List<Coupons> CouponsU { get; set; }
        public List<Shipping> ShippingU { get; set; }
        public List<SystemContact> SystemContactU { get; set; }

        public bool IsDelete { set; get; }




    }
}

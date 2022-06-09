using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thinh_Ecom.Entities
{
    public class Shipping
    {
        public string ship_Id { set; get; }
        public string ship_Name { set; get; }
        public int ship_Price { set; get; }

        //User Create

        public string ship_AppUserFK { set; get; }
        public AppUser AppUser { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thinh_Ecom.Entities
{
    public class Coupons
    {
        public string couponId { set; get; }
        public string couponCode { set; get; }
        public int couponPrice { set; get; }
        public int couponPricePercen { set; get; }

        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }

        public string coupon_AppUserFK { set; get; }
        public AppUser AppUser { get; set; }
    }
}

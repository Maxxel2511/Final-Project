using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thinh_Ecom.Entities
{
    public class Bills
    {
        public string bill_Id { set; get; }
        public AppUser AppUserB { get; set; }
        public string bill_UserId { set; get; }
        public int bill_PaidTotal { set; get; }
        public string bill_ProductIdlist { set; get; }
        public string bill_ProductNamelist { set; get; }
        public string bill_ProductSizelist { set; get; }
        public string bill_ProductPricelist { set; get; }
        public int bill_Shipping { set; get; }
        public int bill_Discount { set; get; }
        public bool bill_Confirmation { set; get; }
        public DateTime bill_DatetimeOrder { set; get; }
        public string bill_PaymentMethod { set; get; }
        public string bill_Note { set; get; }
        public string bill_QuantityList { set; get; }
        public bool bill_HideStatus { set; get; }
        public bool bill_WaitForConfirmation { set; get; }
        public bool IsDelete { set; get; }

    }
}

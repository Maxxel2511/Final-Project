using System;
using System.Collections.Generic;

namespace Thinh_Ecom.Models
{
    public class HistoryPaymentModels
    {
        public string PaymentId { get; set; }
        public DateTime Date { get; set; }
        public string NameUser { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public int Email { get; set; }
        public bool Status_Confirm { get; set; }
        public string Name_Product { get; set; }
        public string Type_Payment { get; set; }
        public bool Check_Receive { get; set; }
        public int SupTotal { get; set; }
        public int Discount { get; set; }
        public int Shipping { get; set; }
        public int Price { get; set; }
    }
}

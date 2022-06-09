namespace Thinh_Ecom.Models
{
    public class CartModels
    {
        
        public string cart_ProductId { get; set; }
        public string cart_ProductName { get; set; }
        public string cart_ProductType { get; set; }
        public int cart_ProductQuantity { get; set; }
        public int cart_ProductPrice { get; set; }
        public string cart_ProductSize { get; set; }
        public string cart_ProductImg { get; set; }
        public int cart_totalPrice { set; get; }
    }
}

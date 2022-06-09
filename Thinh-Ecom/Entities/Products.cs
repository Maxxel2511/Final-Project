using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Thinh_Ecom.Entities
{
    public class Products
    {

        [DisplayName("Id")]
        public string pd_Id { set; get; }

        [DisplayName("Name Product")]
        public string pd_Name { set; get; }
        [DisplayName("Description")]
        public string pd_Description { set; get; }

        [DisplayName("Price")]
        public int pd_Price { set; get; }

        [DisplayName("ReducePrice")]
        public int pd_ReducePrice { set; get; }

        [DisplayName("Img1")]
        public string pd_Img1 { set; get; }

        [DisplayName("ShortDescription")]
        public string pd_ShortDescription { set; get; }

        [DisplayName("Size")]
        public string pd_Size { set; get; }

        public string CategoriesFK  { set; get; }
        public Categories Categories { get; set; }

        public List<ProductInCart> ProductInCartP { get; set; }
        public bool IsDelete { set; get; }
    }
}

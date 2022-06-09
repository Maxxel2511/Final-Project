using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thinh_Ecom.Models
{
    public class ProductModels
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

        [NotMapped]
        [DisplayName("Image (350x200)")]
        public IFormFile pd_Img1 { set; get; }

        [DisplayName("ShortDescription")]
        public string pd_ShortDescription { set; get; }

        [DisplayName("Size")]
        public string pd_Size { set; get; }

        public string CategoriesFK { set; get; }

    }
}

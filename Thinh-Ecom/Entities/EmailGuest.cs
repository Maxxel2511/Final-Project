using System.ComponentModel;

namespace Thinh_Ecom.Entities
{
    public class EmailGuest
    {
        public string Id { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
    }
}

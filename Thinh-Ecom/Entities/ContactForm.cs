using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Thinh_Ecom.Entities
{
    public class ContactForm
    {

        public string cf_Id { set; get; }

        [DisplayName("Name")]
        public string cf_Name { set; get; }

        [DisplayName("Phone")]
        public int cf_Phone { set; get; }

        [DisplayName("Email")]
        public string cf_Email { set; get; }

        [DisplayName("Subject")]
        public string cf_Subject { set; get; }

        [DisplayName("Description")]
        public string cf_Description { set; get; }

    }
}

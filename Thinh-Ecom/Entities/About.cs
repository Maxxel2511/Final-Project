using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thinh_Ecom.Entities
{
    public class About
    {

        public int about_id { set; get; }

        public string about_Url { set; get; }
        public string about_Title { set; get; }
        

        public string about_Description { set; get; }

        // User 
        public string about_AppUserFK { set; get; }
        public AppUser AppUser { get; set; }

    }
}

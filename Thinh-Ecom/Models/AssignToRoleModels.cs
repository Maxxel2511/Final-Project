﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Thinh_Ecom.Models
{
    public class AssignToRoleModels
    {
        [Key]
        public string UserId { get; set; }
        public string RoleId { get; set; }

    }
}

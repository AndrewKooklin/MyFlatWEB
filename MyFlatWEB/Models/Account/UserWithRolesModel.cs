﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Models.Account
{
    public class UserWithRolesModel
    {
        public IdentityUser User { get; set; }

        public List<string> Roles { get; set; }

        //[Required(ErrorMessage = "Выберите \"Роль\"")]
        [Display(Name = "Role")]
        public string Role { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }

        public string Add { get; set; }

        public string Delete { get; set; }
    }
}

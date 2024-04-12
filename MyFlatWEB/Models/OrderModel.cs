using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFlatWEB.Models
{
    public class OrderModel
    {
        [Required(ErrorMessage = "Заполните поле \"Name\"")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните поле \"Email\"")]
        [EmailAddress(ErrorMessage = "Поле Email формата name@site.com")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Заполните поле \"Mobile\"")]
        [MinLength(11, ErrorMessage = "Длина не менее 11 символов.")]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Заполните поле \"Message\"")]
        [MinLength(5, ErrorMessage = "Длина не менее 5 символов.")]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [Display(Name = "CategoryName")]
        public string CategoryName { get; set; }

        public IEnumerable<SelectListItem> CategoryServiceNames { get; set; }
    }
}

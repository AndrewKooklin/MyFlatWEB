using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFlatWEB.Models.Rendering
{
    public class OrderModel : BaseModel
    {
        [Required]
        public DateTime DateCreate { get; set; }

        [Required(ErrorMessage = "Заполните поле \"Name\"")]
        [MinLength(3, ErrorMessage = "Длина не менее 3 символов.")]
        [Display(Name = "Your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните поле \"Email\"")]
        [EmailAddress(ErrorMessage = "Поле Email формата name@site.com")]
        [Display(Name = "Your Email")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Заполните поле \"Mobile\"")]
        //[Phone]
        //[MinLength(11, ErrorMessage = "Длина не менее 11 символов.")]
        [Display(Name = "Your Mobile")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Заполните поле \"Message\"")]
        [MinLength(5, ErrorMessage = "Длина не менее 5 символов.")]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [Required]
        [Display(Name = "Choose A Service")]
        public string ServiceName { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> ServiceNames { get; set; }

        [Required]
        [Display(Name = "StatusName")]
        public string StatusName { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> StatusNames { get; set; }
    }
}

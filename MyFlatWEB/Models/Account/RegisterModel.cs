using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFlatWEB.Models.Account
{
    [AllowAnonymous]
    public class RegisterModel
    {
        [Required(ErrorMessage = "Fill field \"Email\"")]
        [EmailAddress(ErrorMessage = "Email field format name@site.com")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Fill field \"Password\"")]
        [MinLength(6, ErrorMessage = "At least 6 characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repeat password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Field \"Password\" и \"Confirm password\" don't match.")]
        public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "Choose field \"Role\"")]
        [Display(Name = "Role")]
        public string Role { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}

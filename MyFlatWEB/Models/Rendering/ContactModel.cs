using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Models.Rendering
{
    public class ContactModel : BaseModel
    {
        [Required(ErrorMessage = "Fill in the field \"Address\"")]
        [MinLength(3, ErrorMessage = "Length of at least 3 characters.")]
        [Display(Name = "Contact Address")]
        public string ContactAddress { get; set; }

        [Required(ErrorMessage = "Fill in the field \"Phone\"")]
        [Phone]
        [MinLength(11, ErrorMessage = "Length of at least 11 characters.")]
        [Display(Name = "Contact Phone")]
        public string ContactPhone { get; set; }

        [Required(ErrorMessage = "Fill in the field \"Email\"")]
        [EmailAddress(ErrorMessage = "View field \"name@example.com\"")]
        [Display(Name = "Contact Phone")]
        public string ContactEmail { get; set; }
    }
}

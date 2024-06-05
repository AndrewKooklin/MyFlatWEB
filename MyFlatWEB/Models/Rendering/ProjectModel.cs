using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Models.Rendering
{
    public class ProjectModel : BaseModel
    {
        [Required(ErrorMessage = "Select a picture")]
        [Display(Name = "Project Image")]
        public byte[] ProjectImage { get; set; }

        [Required(ErrorMessage = "Fill in the field \"Header\"")]
        [MinLength(3, ErrorMessage = "Length of at least 3 characters.")]
        [Display(Name = "Project Header")]
        public string ProjectHeader { get; set; }

        [Required(ErrorMessage = "Fill in the field \"Description\"")]
        [MinLength(3, ErrorMessage = "Length of at least 3 characters.")]
        [Display(Name = "Project Description")]
        public string ProjectDescription { get; set; }
    }
}

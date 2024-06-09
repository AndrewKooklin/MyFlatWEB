using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Models.Rendering
{
    public class SocialModel : BaseModel
    {
        [Required(ErrorMessage = "Select a picture")]
        [Display(Name = "Social Image")]
        public byte[] SocialImage { get; set; }

        [Required(ErrorMessage = "Fill in the field \"Social Link\"")]
        [Url(ErrorMessage = "View field \"http(s)://www.example.com/\"")]
        [Display(Name = "Social Link")]
        public string SocialLink { get; set; }
    }
}

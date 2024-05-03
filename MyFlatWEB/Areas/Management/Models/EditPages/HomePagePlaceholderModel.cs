﻿using MyFlatWEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Areas.Management.Models.EditPages
{
    public class HomePagePlaceholderModel : BaseModel
    {
        public List<TopMenuLinkNameModel> LinkNames { get; set; }

        public List<RandomPhraseModel> RandomPhrases { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Minimum length 3 chars")]
        [MaxLength(50, ErrorMessage = "Maximum length 50 chars")]
        public string LeftCentralAreaText { get; set; }

        [Required(ErrorMessage = "Select picture")]
        public byte[] MainPicture { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Minimum length 3 chars")]
        [MaxLength(30, ErrorMessage = "Maximum length 30 chars")]
        public string BottomAreaHeader { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Minimum length 3 chars")]
        [MaxLength(500, ErrorMessage = "Maximum length 500 chars")]
        public string BottomAreaContent { get; set; }
    }
}

﻿using MyFlatWEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Areas.Management.Models.Rendering
{
    public class ServiceModel : BaseModel
    {
        [Required]
        [MinLength(3)]
        public string ServiceName { get; set; }

        [Required]
        [MinLength(3)]
        public string ServiceDescription { get; set; }
    }
}

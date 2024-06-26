﻿using MyFlatWEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Areas.Management.Models.EditPages
{
    public class TopMenuLinkNameModel : BaseModel
    {
        public string LinkName { get; set; }

        public string ActionMethod { get; set; }

        [NotMapped]
        public string InputLinkNameError { get; set; }
    }
}

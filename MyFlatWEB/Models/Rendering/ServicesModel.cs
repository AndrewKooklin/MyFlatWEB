﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Models.Rendering
{
    public class ServicesModel
    {
        public static IEnumerable<SelectListItem> ServiceNames { get; set; }
    }
}

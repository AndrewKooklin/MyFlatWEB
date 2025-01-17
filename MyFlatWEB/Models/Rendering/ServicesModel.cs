using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyFlatWEB.Models.Rendering
{
    public class ServicesModel
    {
        public static IEnumerable<SelectListItem> ServiceNames { get; set; }
    }
}

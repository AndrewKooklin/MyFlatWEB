using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlatWEB.Areas.Management.Models.Rendering
{
    public class InputDataModel
    {

        [Required(ErrorMessage = "Fill date")]
        //[Remote(action: "OrdersByPeriod", controller: "ManageView", ErrorMessage = "Fill date from")]
        public string DateFrom { get; set; } = "";

        [Required(ErrorMessage = "Fill date")]
        //[Remote(action: "OrdersByPeriod", controller: "ManageView", ErrorMessage = "Fill date to")]
        public string DateTo { get; set; } = "";
    }
}

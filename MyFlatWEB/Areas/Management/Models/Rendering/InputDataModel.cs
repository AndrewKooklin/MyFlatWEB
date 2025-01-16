using System.ComponentModel.DataAnnotations;

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

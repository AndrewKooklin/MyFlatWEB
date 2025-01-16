using MyFlatWEB.Models;
using System.ComponentModel.DataAnnotations.Schema;

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

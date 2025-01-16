using MyFlatWEB.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFlatWEB.Areas.Management.Models.EditPages
{
    public class RandomPhraseModel : BaseModel
    {
        public string Phrase { get; set; }

        [NotMapped]
        public string InputChangePhraseError { get; set; }
    }
}

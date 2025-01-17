using System.ComponentModel.DataAnnotations;

namespace MyFlatWEB.Models
{
    public class BaseModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}

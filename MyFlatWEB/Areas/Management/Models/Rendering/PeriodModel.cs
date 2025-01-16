using System;
using System.ComponentModel.DataAnnotations;

namespace MyFlatWEB.Areas.Management.Models.Rendering
{
    public class PeriodModel
    {
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DateFrom { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DateTo { get; set; }
    }
}

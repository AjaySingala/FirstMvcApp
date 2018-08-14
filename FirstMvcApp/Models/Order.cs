using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstMvcApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Order Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime OrderDate { get; set; }
        [Required]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
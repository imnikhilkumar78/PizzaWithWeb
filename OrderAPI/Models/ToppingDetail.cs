using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OrderApi.Models
{
   
    public class ToppingDetail
    {
        [Key]
      
        public int toppingDetailId { get; set; }
        [Required(ErrorMessage = "Item ID is required")]
       
        public int ItemId { get; set; }
        [Required(ErrorMessage = "Topping ID is required")]
       
        public int ToppingId { get; set; }

        [ForeignKey("ItemId")]
      
        public virtual OrderDetail OrderDetail { get; set; }
    }
}

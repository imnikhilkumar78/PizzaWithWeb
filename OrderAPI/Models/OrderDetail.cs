using OrderApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

#nullable disable

namespace OrderApi.Models
{
    
    public partial class OrderDetail
    {
        [Key]
        public int ItemId { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public int PizzaId { get; set; }

        public virtual Order Order { get; set; }
      // public virtual Pizza Pizza { get; set; }
       
    }
}

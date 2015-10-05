using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace LoveMeBetter.Models.Order
{
    public class Product
    {
        [Key]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        public decimal Price { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool IsSubscriptionProduct { get; set; }

        [Required]
        public virtual ICollection<OrderDetails> OrdersDetails { get; set; } 
    }
}
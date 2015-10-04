using System.ComponentModel.DataAnnotations;

namespace LoveMeBetter.Models.Order
{
    public class OrderDetails
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public decimal PriceWhenBought { get; set; }

        [Required]
        public virtual Order Order { get; set; }

        [Required]
        public virtual Product Product{ get; set; }

        public virtual RandomizedProductCategory RandomizedProductCategory { get; set; }
    }
}
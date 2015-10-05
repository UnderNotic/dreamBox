using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoveMeBetter.Models.Order
{
    public class RandomizedProductCategory //need to think about it
    {
        [Key]
        public string Name { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
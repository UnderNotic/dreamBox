using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity.Infrastructure.Annotations;

namespace LoveMeBetter.Models.Order
{
    public class RandomizedProductCategory //need to think about it
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
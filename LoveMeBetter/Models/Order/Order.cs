using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LoveMeBetter.Enums;

namespace LoveMeBetter.Models.Order
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        [DefaultValue(DiscountEnum.None)]
        public DiscountEnum DiscountType { get; set; }

        [Required]
        [DefaultValue(Enums.TransactionStatusEnum.Unpaid)]
        public TransactionStatusEnum TransactionStatusEnum { get; set; }

        [Required]
        public virtual ICollection<OrderDetails> OrdersDetails { get; set; }

        public Order()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWD392.DB
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ApplicationUser User { get; set; }
    }
}

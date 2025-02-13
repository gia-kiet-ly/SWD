﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWD392.DB
{
    [Table("ManufacturedCountry")]
    public class ManufacturedCountry
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Product> products { get; set; } = new List<Product>();
    }
}

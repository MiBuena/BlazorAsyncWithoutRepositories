using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ListGenerator.Data.Entities
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        [Required]
        public DateTime ReplenishmentDate { get; set; }
    }
}

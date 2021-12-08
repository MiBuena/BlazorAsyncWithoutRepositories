using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ListGenerator.Data.Entities
{ 
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public double ReplenishmentPeriod { get; set; }

        [Required]
        public DateTime NextReplenishmentDate { get; set; }

        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}

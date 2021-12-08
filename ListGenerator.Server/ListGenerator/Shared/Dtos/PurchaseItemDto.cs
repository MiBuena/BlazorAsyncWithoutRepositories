using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Shared.Dtos
{
    public class PurchaseItemDto
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime ReplenishmentDate { get; set; }
    }
}

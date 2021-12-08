using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Shared.Dtos
{
    public class ReplenishmentItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public bool ItemNeedsReplenishmentUrgently { get; set; }

        public DateTime NextReplenishmentDate { get; set; }

        public DateTime ReplenishmentDate { get; set; }
    }
}

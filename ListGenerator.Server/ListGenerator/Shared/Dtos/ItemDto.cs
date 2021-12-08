using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Shared.Dtos
{
    public class ItemDto : ItemNameDto
    {
        public int Id { get; set; }

        public double ReplenishmentPeriod { get; set; }

        public DateTime NextReplenishmentDate { get; set; }
    }
}

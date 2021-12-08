using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Shared.Dtos
{
    public class ItemOverviewDto : ItemDto
    {
        public DateTime? LastReplenishmentDate { get; set; }

        public int? LastReplenishmentQuantity { get; set; }
    }
}

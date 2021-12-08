using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Shared.Dtos
{
    public class ItemsOverviewPageDto
    {
        public int TotalItemsCount { get; set; }
        public IEnumerable<ItemOverviewDto> OverviewItems { get; set; } = new List<ItemOverviewDto>();
    }
}

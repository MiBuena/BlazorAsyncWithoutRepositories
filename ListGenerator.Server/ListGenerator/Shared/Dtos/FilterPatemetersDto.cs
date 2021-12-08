using ListGenerator.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Shared.Dtos
{
    public class FilterPatemetersDto
    {
        public int? PageSize { get; set; }

        public int? SkipItems { get; set; }

        public string OrderByColumn { get; set; }

        public SortingDirection? OrderByDirection { get; set; }

        public string SearchWord { get; set; }

        public string SearchDate { get; set; }
    }
}

using ListGenerator.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListGenerator.Client.Models
{
    public class SortingData
    {
        public string OrderByColumn { get; set; }
        public SortingDirection? OrderByDirection { get; set; }
    }
}

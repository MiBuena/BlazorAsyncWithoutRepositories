using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Client.ViewModels
{
    public class PurchaseItemViewModel
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public string Quantity { get; set; } = "1";

        public DateTime NextReplenishmentDate { get; set; }

        public string ReplenishmentSignalClass { get; set; }

        public DateTime ReplenishmentDate { get; set; }
    }
}

using ListGenerator.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Client.Models
{
    public class ItemsOverviewResponse : ApiResponse
    {
        public IEnumerable<ItemViewModel> Items { get; set; } = new List<ItemViewModel>();
    }
}

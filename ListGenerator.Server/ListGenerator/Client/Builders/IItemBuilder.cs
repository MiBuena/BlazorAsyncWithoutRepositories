using ListGenerator.Shared.Dtos;
using ListGenerator.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListGenerator.Client.Builders
{
    public interface IItemBuilder
    {
        ItemViewModel BuildItemViewModel();
    }
}

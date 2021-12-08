using AutoMapper;
using ListGenerator.Shared.Dtos;
using ListGenerator.Client.ViewModels;
using ListGenerator.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace ListGenerator.Client.Components
{
    public partial class DeleteItemDialog
    {
        [Inject]
        public IItemService ItemService { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        public ItemViewModel Item { get; set; }

        public bool ShowDialog { get; set; }

        public ErrorComponent Error { get; set; }

        protected async Task DeleteItem()
        {
            var response = await ItemService.DeleteItem(Item.Id);

            if(!response.IsSuccess)
            {
                this.Error.Show(response.ErrorMessage);
            }
            else
            {
                ShowDialog = false;
                await CloseEventCallback.InvokeAsync(true);
            }

            StateHasChanged();
        }

        public async void Show(int id)
        {
            var response = await this.ItemService.GetItem(id);

            ShowDialog = true;
            StateHasChanged();

            if (response.IsSuccess)
            {
                this.Item = Mapper.Map<ItemDto, ItemViewModel>(response.Data);
            }
            else
            {
                this.Error.Show(response.ErrorMessage);
            }

            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            this.Item = null;
            StateHasChanged();
        }
    }
}

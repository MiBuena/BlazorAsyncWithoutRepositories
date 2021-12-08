using AutoMapper;
using ListGenerator.Shared.Dtos;
using ListGenerator.Client.ViewModels;
using ListGenerator.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListGenerator.Client.Components
{
    public partial class EditItemDialog
    {
        public ItemViewModel ItemToUpdate { get; set; }

        [Inject]
        public IItemService ItemService { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        public bool ShowDialog { get; set; }

        public ErrorComponent Error { get; set; }

        public async void Show(int id)
        {
            var response = await this.ItemService.GetItem(id);

            ShowDialog = true;
            StateHasChanged();

            if (response.IsSuccess)
            {
                this.ItemToUpdate = Mapper.Map<ItemDto, ItemViewModel>(response.Data);
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
            this.ItemToUpdate = null;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await ItemService.UpdateItem(ItemToUpdate);

            if (!response.IsSuccess)
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
    }
}

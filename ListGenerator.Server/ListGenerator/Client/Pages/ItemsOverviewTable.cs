using AutoMapper;
using ListGenerator.Client.Components;
using ListGenerator.Client.Services;
using ListGenerator.Client.ViewModels;
using ListGenerator.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListGenerator.Client.Pages
{
    [Authorize]
    public partial class ItemsOverviewTable
    {
        private string SearchWord { get; set; }

        private DateTime? SearchDate { get; set; }

        private int Count { get; set; }

        [Inject]
        private IItemService ItemsService { get; set; }

        [Inject]
        private IMapper Mapper { get; set; }

        private IEnumerable<ItemNameDto> DisplayItemsNames { get; set; }

        private IEnumerable<ItemOverviewViewModel> DisplayItems { get; set; }

        private AddItemDialog AddItemDialog { get; set; }

        private EditItemDialog EditItemDialog { get; set; }

        private DeleteItemDialog DeleteItemDialog { get; set; }

        private ErrorComponent Error { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private RadzenGrid<ItemOverviewViewModel> Table { get; set; }


        private async Task LoadData(LoadDataArgs args)
        {
            var response = await this.ItemsService.GetItemsOverviewPageModel(args.Top, args.Skip, args.OrderBy, this.SearchWord, this.SearchDate);
           
            if (!response.IsSuccess)
            {
                this.Error.Show(response.ErrorMessage);
            }

            if (response.Data != null)
            {
                this.DisplayItems = response.Data.OverviewItems.Select(x => Mapper.Map<ItemOverviewDto, ItemOverviewViewModel>(x));
                this.Count = response.Data.TotalItemsCount;
            }

            await InvokeAsync(StateHasChanged);
        }

        private async void ClearFilters()
        {
            this.SearchWord = null;
            this.SearchDate = null;

            await Table.Reload();
            StateHasChanged();
        }

        private async void LoadAutoCompleteData(LoadDataArgs args)
        {
            var response = await ItemsService.GetItemsNames(args.Filter);

            if(!response.IsSuccess)
            {
                this.Error.Show(response.ErrorMessage);
            }

            this.DisplayItemsNames = response.Data;
            await InvokeAsync(StateHasChanged);
        }

        private async void Search()
        {
            await Table.Reload();
            StateHasChanged();
        }

        private void QuickAddItem()
        {
            AddItemDialog.Show();
        }

        private async void AddItemDialog_OnDialogClose()
        {
            await Table.Reload();
            StateHasChanged();
        }

        private void QuickEditItem(int id)
        {
            EditItemDialog.Show(id);
        }

        private async void EditItemDialog_OnDialogClose()
        {
            await Table.Reload();
            StateHasChanged();
        }

        private void DeleteItemQuestion(int id)
        {
            DeleteItemDialog.Show(id);
        }

        private async void DeleteItemDialog_OnDialogClose()
        {
            await Table.Reload();
            StateHasChanged();
        }

        private async void Reload_OnCultureChange()
        {
            await Table.Reload();
            StateHasChanged();
        }

        private void NavigateToListGeneration()
        {
            NavigationManager.NavigateTo("/shoppinglist");
        }
    }
}

using AutoMapper;
using ListGenerator.Shared.Dtos;
using ListGenerator.Client.ViewModels;
using ListGenerator.Client.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListGenerator.Shared.Interfaces;
using ListGenerator.Client.Builders;
using ListGenerator.Client.Components;

namespace ListGenerator.Client.Pages
{
    [Authorize]
    public partial class ShoppingList
    {
        [Inject]
        private IReplenishmentService ReplenishmentService { get; set; }

        [Inject]
        private IDateTimeProvider DateTimeProvider { get; set; }

        [Inject]
        private IMapper Mapper { get; set; }


        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IItemBuilder ItemBuilder { get; set; }

        [Inject]
        private IReplenishmentBuilder ReplenishmentBuilder { get; set; }

        private List<PurchaseItemViewModel> ReplenishmentItems { get; set; } = new List<PurchaseItemViewModel>();

        private DateTime FirstReplenishmentDate { get; set; }

        private DateTime SecondReplenishmentDate { get; set; }

        private DayOfWeek UsualShoppingDay { get; set; }

        private DateTime DateTimeNow { get; set; }

        private ErrorComponent Error { get; set; }

        private async Task ChangeFirstReplenishmentDateValue(ChangeEventArgs e)
        {
            this.FirstReplenishmentDate = DateTime.Parse(e.Value.ToString());
            await InitializeReplenishmentItemsCollection();
        }

        private async Task ChangeSecondReplenishmentDateValue(ChangeEventArgs e)
        {
            this.SecondReplenishmentDate = DateTime.Parse(e.Value.ToString());
            await InitializeReplenishmentItemsCollection();
        }

        protected override async Task OnInitializedAsync()
        {
            this.DateTimeNow = DateTimeProvider.GetDateTimeNowDate();
            this.UsualShoppingDay = DayOfWeek.Sunday;

            await GenerateListFromDayOfWeek();
        }

        private async Task InitializeReplenishmentItemsCollection()
        {
            var response = await ReplenishmentService.GetShoppingListItems(this.FirstReplenishmentDate, this.SecondReplenishmentDate);

            if (!response.IsSuccess)
            {
                this.Error.Show(response.ErrorMessage);
            }

            if (response.Data != null)
            {
                this.ReplenishmentItems = response.Data.Select(x => Mapper.Map<ReplenishmentItemDto, PurchaseItemViewModel>(x)).ToList();
            }
        }

        private async Task RegenerateListFromDayOfWeek(ChangeEventArgs e)
        {
            this.UsualShoppingDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), e.Value.ToString());
            await GenerateListFromDayOfWeek();
        }

        private async Task GenerateListFromDayOfWeek()
        {
            this.FirstReplenishmentDate = GetNextShoppingDay(UsualShoppingDay);
            this.SecondReplenishmentDate = this.FirstReplenishmentDate.AddDays(7);

            await InitializeReplenishmentItemsCollection();
        }

        private DateTime GetNextShoppingDay(DayOfWeek usualShoppingDay)
        {
            DateTime today = DateTimeProvider.GetDateTimeNowDate();
            int daysUntilUsualShoppingDay = ((int)usualShoppingDay - (int)today.DayOfWeek + 7) % 7;
            DateTime nextShoppingDay = today.AddDays(daysUntilUsualShoppingDay);

            return nextShoppingDay;
        }

        private async Task ReplenishItem(int itemId)
        {
            var viewModel = this.ReplenishmentItems.FirstOrDefault(x => x.ItemId == itemId);
            var replenishmentModel = ReplenishmentBuilder.BuildReplenishmentDto(this.FirstReplenishmentDate, this.SecondReplenishmentDate, viewModel);

            await this.ReplenishmentService.ReplenishItems(replenishmentModel);

            var response = await ReplenishmentService.GetShoppingListItems(this.FirstReplenishmentDate, this.SecondReplenishmentDate);

            if (!response.IsSuccess)
            {
                this.Error.Show(response.ErrorMessage);
            }

            if (response.Data != null)
            {
                this.ReplenishmentItems = response.Data.Select(x => Mapper.Map<ReplenishmentItemDto, PurchaseItemViewModel>(x)).ToList();
            }
        }

        private async Task ReplenishAllItems()
        {
            var replenishmentModel = ReplenishmentBuilder.BuildReplenishmentDto(this.FirstReplenishmentDate, this.SecondReplenishmentDate, this.ReplenishmentItems);

            await this.ReplenishmentService.ReplenishItems(replenishmentModel);
            NavigateToAllItems();
        }

        private void NavigateToAllItems()
        {
            NavigationManager.NavigateTo("/allitemstable");
        }
    }
}

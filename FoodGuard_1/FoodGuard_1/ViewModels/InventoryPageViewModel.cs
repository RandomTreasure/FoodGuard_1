using FoodGuard_1.Models;
using FoodGuard_1.Services;
using FoodGuard_1.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodGuard_1.ViewModels
{
    public class InventoryPageViewModel : ViewModelTemplate
    {
        public ObservableRangeCollection<FoodItem> Inventory { get; set; }

        public DummyData data = new DummyData();

        public AsyncCommand AddCommand { get; }
        public InventoryPageViewModel()
        {
            Title = "Frigorifero";
            Inventory = new ObservableRangeCollection<FoodItem>();
            Inventory = data.GetData();


            /*Inventory = new ObservableRangeCollection<FoodItem>()
            {
                new FoodItem() { Id = 1 , Name = "Mozzarella", Quantity = 1, ExpiryDate = DateTime.UtcNow, Tags = "Frigo,Latticini" },
                new FoodItem() { Id = 2 , Name = "Emmenthal", Quantity = 1, ExpiryDate = DateTime.UtcNow, Tags = "Frigo,Latticini" },
                new FoodItem() { Id = 3 , Name = "Brie", Quantity = 1, ExpiryDate = DateTime.UtcNow, Tags = "Frigo,Latticini" },
            };*/

            AddCommand = new AsyncCommand(AddItem);

        }

        public async Task AddItem()
        {
            var route = $"{nameof(AddProductPage)}";
            await Shell.Current.GoToAsync(route);

        }
    }
}

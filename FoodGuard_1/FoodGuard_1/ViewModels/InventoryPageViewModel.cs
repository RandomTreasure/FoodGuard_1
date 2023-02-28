using FoodGuard_1.Models;
using FoodGuard_1.Services;
using FoodGuard_1.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodGuard_1.ViewModels
{
    public class InventoryPageViewModel : ViewModelTemplate
    {
        //public ObservableRangeCollection<FoodItem> Inventory { get; set; }

        public List<FoodItem> InventoryList { get; set; }
        public InternetServices service;

       // public DummyData data = new DummyData();

        public AsyncCommand AddCommand { get; }

        public AsyncCommand GetListCommand { get; }

        //public AsyncCommand RefreshLocalDBCommand { get; }
        public InventoryPageViewModel()
        {
            Title = "Frigorifero";

            service = new InternetServices();

            GetListCommand = new AsyncCommand(GetList);

            //InventoryList = new List<FoodItem>();

            //Inventory = new ObservableRangeCollection<FoodItem>();
            //Inventory = data.GetData();


            /*Inventory = new ObservableRangeCollection<FoodItem>()
            {
                new FoodItem() { Id = 1 , Name = "Mozzarella", Quantity = 1, ExpiryDate = DateTime.UtcNow, Tags = "Frigo,Latticini" },
                new FoodItem() { Id = 2 , Name = "Emmenthal", Quantity = 1, ExpiryDate = DateTime.UtcNow, Tags = "Frigo,Latticini" },
                new FoodItem() { Id = 3 , Name = "Brie", Quantity = 1, ExpiryDate = DateTime.UtcNow, Tags = "Frigo,Latticini" },
            };*/

            AddCommand = new AsyncCommand(AddItem);
           // RefreshLocalDBCommand = new AsyncCommand(RefreshLocalDB);

        }

        public async Task AddItem()
        {
            var route = $"{nameof(AddProductPage)}";
            await Shell.Current.GoToAsync(route);

        }
/*
        public async Task RefreshLocalDB()
        {
            service = new InternetServices();

            await GeneralServices.GetFrigo(service.client);

            InventoryList = GeneralServices.GetFood();

        }
*/
        public async Task GetList()
        {
            /*InventoryList = await service.GetInventoryByJson();

            Debug.WriteLine(InventoryList.Count);
            
            IsBusy = true;

            await Task.Delay(2000);

            InventoryList.Clear();

            var coffees = await service.GetJson();

            InventoryList.AddRange(coffees);

            IsBusy = false;
            */
        }
    }
}

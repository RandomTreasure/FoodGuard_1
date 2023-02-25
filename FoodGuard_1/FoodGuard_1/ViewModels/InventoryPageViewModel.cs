using FoodGuard_1.Models;
using FoodGuard_1.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodGuard_1.ViewModels
{
    public class InventoryPageViewModel : ViewModelTemplate
    {
        public ObservableRangeCollection<FoodItem> Inventory;

        public DummyData data = new DummyData();

        public InventoryPageViewModel()
        {
            Title = "Frigorifero";
            Inventory = data.GetData();
        }
    }
}

using FoodGuard_1.Models;
using MvvmHelpers;
using System;

namespace FoodGuard_1.Services
{
    public class DummyData
    {
        public ObservableRangeCollection<FoodItem> data;
        public ObservableRangeCollection<Grouping<string,FoodItem>> dataGroups;

        public DummyData()
        {
            data = new ObservableRangeCollection<FoodItem>()
            {
                new FoodItem() { Id = 1 , Name = "Mozzarella", Quantity = 1, ExpiryDate = DateTime.UtcNow, Tags = "Frigo,Latticini" },
                new FoodItem() { Id = 2 , Name = "Emmenthal", Quantity = 1, ExpiryDate = DateTime.UtcNow, Tags = "Frigo,Latticini" },
                new FoodItem() { Id = 3 , Name = "Brie", Quantity = 1, ExpiryDate = DateTime.UtcNow, Tags = "Frigo,Latticini" },
            };
        }

        public ObservableRangeCollection<FoodItem> GetData()
        {
            return data;
        }
    }
}

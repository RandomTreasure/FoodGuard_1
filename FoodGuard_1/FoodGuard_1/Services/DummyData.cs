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
        {/*
            data = new ObservableRangeCollection<FoodItem>()
            {
                new FoodItem() { Id = 1 , Name = "Mozzarella", Buy = 1 },
                new FoodItem() { Id = 2 , Name = "Emmenthal", Buy = 2 },
                new FoodItem() { Id = 3 , Name = "Brie", Buy = 3 }
            };*/
        }
        //ExpiryDate = DateTime.UtcNow
        //Tags = "Frigo,Latticini" 
        public ObservableRangeCollection<FoodItem> GetData()
        {
            throw new NotImplementedException();
            //return data;
        }
    }
}

using FoodGuard_1.Models;
using FoodGuard_1.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodGuard_1.ViewModels
{
    public class AddProductPageViewModel : ViewModelTemplate
    {
        public string EntryName { get; set; }
       // public string EntryTags { get; set; }
        public int EntryBuy { get; set; }
        public int EntryId { get; set; }
        public int EntryExp { get; set; }

        public AsyncCommand SaveCommand { get; }

        public AsyncCommand RemoveCommand { get; }
        public DateTime SelectDate { get; set; }
        public InternetServices service;



        // this stuff here is where the server should actually be called to save some items
        //public DummyData data = new DummyData();
        public ObservableRangeCollection<FoodItem> dataSample { get; set; }
        //
        
        public AddProductPageViewModel()
        {
        
            service = new InternetServices();
            SaveCommand = new AsyncCommand(SaveToServer);
            RemoveCommand = new AsyncCommand(RemoveFromServer);

            // ^
            //dataSample = new ObservableRangeCollection<FoodItem>();
            //dataSample = data.GetData();
        }

        public async Task SaveToServer()
        {
            //dataSample.Add( new FoodItem { Id = 4, Name = EntryName, Quantity = 1, Tags = EntryTags, ExpiryDate = SelectDate

            await service.UploadToFrigo1(new FoodItem { Id = EntryId, Name = EntryName, Buy = EntryBuy, Exp = EntryExp });

            await Shell.Current.GoToAsync("..");
        }

        public async Task RemoveFromServer()
        {
            await service.RemoveFromFrigo(EntryId);
        }
    }
}

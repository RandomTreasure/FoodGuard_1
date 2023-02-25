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
        public string EntryTags { get; set; }
        public AsyncCommand SaveCommand { get; }
        public DateTime SelectDate { get; set; }


        // this stuff here is where the server should actually be called to save some items
        public DummyData data = new DummyData();
        public ObservableRangeCollection<FoodItem> dataSample { get; set; }
        //
        
        public AddProductPageViewModel()
        {
            
            SaveCommand = new AsyncCommand(Save);

            // ^
            dataSample = new ObservableRangeCollection<FoodItem>();
            dataSample = data.GetData();
        }

        public async Task Save()
        {
            dataSample.Add( new FoodItem { Id = 4, Name = EntryName, Quantity = 1, Tags = EntryTags, ExpiryDate = SelectDate});

           await Shell.Current.GoToAsync("..");
        }
    }
}

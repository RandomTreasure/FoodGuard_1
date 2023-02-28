using FoodGuard_1.Models;
using FoodGuard_1.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodGuard_1.ViewModels
{
    public class RecapPageViewModel : ViewModelTemplate
    {
        public InternetServices service;
        public AsyncCommand GetFromWebCommand { get; }
        public Command TestCommand { get; }
        public int count = 0;

        public string Text
        {
            get => "Bella stringa";
       //     set => SetProperty(ref Text, value);
        }

        public RecapPageViewModel()
        {
            service = new InternetServices();
            GetFromWebCommand = new AsyncCommand(GetFromWeb);
            TestCommand = new Command(Test);
        }

        public async Task<List<FoodItem>> GetFromWeb()
        {
            return await service.GetInventoryByJson();
        }

        public void Test()
        {
            //Console.WriteLine("Premuto Test Button");
            count++;
            //Text = $"Hai premuto il bottone {count} volte";
        }
    }
}

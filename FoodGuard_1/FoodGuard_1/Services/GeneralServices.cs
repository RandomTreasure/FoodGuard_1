using FoodGuard_1.Models;
using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FoodGuard_1.Services
{
    public static class GeneralServices
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            throw new NotImplementedException();
            /*
            if (db != null)
                return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "LocalDB.db");

            db = new SQLiteAsyncConnection(dbPath);

            await db.CreateTableAsync<FoodItem>();
            */
        }

        //public static async Task AddFoodItem

        public static async Task GetAllFoodItems()
        {
            throw new NotImplementedException();
            //await Init();
        }
    }
}

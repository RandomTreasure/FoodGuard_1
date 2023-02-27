using FoodGuard_1.Models;
using SQLite;
using System;
using Microsoft.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FoodGuard_1.Services
{
    public static class GeneralServices
    {
        static SQLiteAsyncConnection db;


        //private static readonly Uri uri = new Uri("http://168.119.117.67:8080/");

        //-- Creates tha db if it doesn't exist
        static async Task Init()
        {
            //throw new NotImplementedException();
            
            if (db != null)
                return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "LocalDB.db");

            db = new SQLiteAsyncConnection(dbPath);

            await db.CreateTableAsync<FoodItem>();
            
        }


        public static async Task AddFood(FoodItem food)
        {
            await Init();

            await db.InsertAsync(food);
        }

        /*
        //-- Copies the db from the server
        public static async Task GetFrigo(HttpClient client)
        {
            await Init();

            //var connection = new SQLiteConnection("LocalDB.db");

            //connection.Open();

            //HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri + "getFrigo");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    File.WriteAllBytes(Path.Combine(FileSystem.AppDataDirectory, "LocalDB.db"), content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

        }

        //public static async Task AddFoodItem

        public static async Task<List<FoodItem>> GetFood()
        {
            await Init();
            var FoodList = await db.Table<FoodItem>().ToListAsync();
            return FoodList;
        }


        /*
        public static async Task GetAllFoodItems()
        {
            //throw new NotImplementedException();
            await Init();
        }
        */
        

    }
}

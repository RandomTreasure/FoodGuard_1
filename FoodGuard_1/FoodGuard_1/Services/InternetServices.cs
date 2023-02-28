using FoodGuard_1.Models;
using FoodGuard_1.Services;
using MvvmHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FoodGuard_1.Services
{
    public class InternetServices
    {
        public HttpClient client;
        public JsonSerializerOptions serializerOptions;

        public List<FoodItem> Items_Web;

        private readonly Uri uri = new Uri("http://168.119.117.67:8080/");

        public InternetServices()
        {
            //if (client == null) 
            //{
                client = new HttpClient();
            //}            


            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
            
        }

        public async Task<List<FoodItem>> GetInventoryByJson()
        {
            Items_Web = new List<FoodItem>();

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri + "getJson");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items_Web = System.Text.Json.JsonSerializer.Deserialize<List<FoodItem>>(content, serializerOptions);
                    
                    /*
                    foreach (FoodItem f in Items_Web)
                    {
                        await GeneralServices.AddFood(f);
                    }
                    */
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items_Web;
        }

        /*
        public async Task GetFrigo()
        {

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri + "getFrigo");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    File.WriteAllBytes(Path.Combine(FileSystem.AppDataDirectory, "CopiedDB.db"), content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

        }

        */



        public async Task UploadToFrigo(FoodItem cibo)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize<FoodItem>(cibo, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8);

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri + "UploadToFrigo", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfull post!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task UploadToFrigo1(FoodItem cibo)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri + 
                    "UploadToFrigo" +
                    $"?id={cibo.Id}&" +
                    $"name=%22{cibo.Name}%22&" +
                    $"buy={cibo.Buy}&" +
                    $"exp={cibo.Exp}"
                    );
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("sesso");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
        public async Task RemoveFromFrigo(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri +
                    "RemoveFromFrigo" +
                    $"?id={id}"
                    
                    );
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("sessoRimosso");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}

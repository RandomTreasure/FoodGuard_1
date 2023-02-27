using FoodGuard_1.Models;
using MvvmHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoodGuard_1.Services
{
    public class InternetServices
    {
        public HttpClient client;
        public JsonSerializerOptions serializerOptions;

        public List<FoodItem> Items_Web;
        
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

        public async Task<List<FoodItem>> GetItems_Web()
        {
            Items_Web = new List<FoodItem>();

            Uri uri = new Uri("http://168.119.117.67:8080/");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri + "getJson");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items_Web = System.Text.Json.JsonSerializer.Deserialize<List<FoodItem>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items_Web;
        }
    }
}

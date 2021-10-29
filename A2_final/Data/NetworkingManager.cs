using A2_final.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace A2_final.Data
{
    public class NetworkingManager
    {
        private static readonly string BaseUrl = "https://trackapi.nutritionix.com/v2";
        private readonly HttpClient Client;
        private static readonly Lazy<NetworkingManager> _instanceHolder = new Lazy<NetworkingManager>(() => new NetworkingManager());

        private NetworkingManager()
        {
            Client = new HttpClient();

            Client.DefaultRequestHeaders.Add("x-app-id", "80b2c6b3");
            Client.DefaultRequestHeaders.Add("x-app-key", "159b4d893a311e985ec9087261157e6a");
        }

        public static NetworkingManager Instance => _instanceHolder.Value;

        public async Task<List<Food>> GetFoodList(string searchValue)
        {
            string url = $"{BaseUrl}/search/instant?common=false&query=${searchValue}";

            try
            {
                Nutrion nutrionData = await Client.GetFromJsonAsync<Nutrion>(url);
                return nutrionData.branded;

            }
            catch
            {
                return new List<Food>();
            }
        }

        public async Task<FoodDetailedData> GetFoodDetails(string nix_item_id)
        {
            string url = $"{BaseUrl}/search/item?nix_item_id={nix_item_id}";

            try
            {
                FoodDetailedDataList response2 = await Client.GetFromJsonAsync<FoodDetailedDataList>(url);
                return response2.foods[0];
            }
            catch
            {
                return new FoodDetailedData();
            }
        }
    }
}
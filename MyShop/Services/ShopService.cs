using MyShop.Models;
using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using Windows.Media.Protection.PlayReady;

namespace MyShop.Services
{
    public class ShopService
    {
        public static HttpClient ApiClient { get; private set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            MessageBox.Show(ConfigurationManager.AppSettings["PateShopApiBaseUrl"]);
            ApiClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["PateShopApiBaseUrl"]);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<object?> LoginAsync(string username, string password)
        {
            var credentials = new
            {
                username = username,
                password = password
            };

            try
            {
                var url = "/auth/login";
                var response = await ApiClient.PostAsJsonAsync(url, credentials);
                //User user = await response.Content.ReadAsAsync<User>();
                var user = await response.Content.ReadAsStringAsync();
                MessageBox.Show(user);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
    }
}

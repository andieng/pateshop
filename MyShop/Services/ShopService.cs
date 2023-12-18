using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;

namespace MyShop.Services
{
    public class ShopService
    {
        public static HttpClient ApiClient { get; private set; }
        public static bool IsConnected { get; private set; }

        public static async void InitializeClient()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri(settings["PateShopApiBaseUrl"].Value);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            await ConnectAsync();
        }

        public static async Task<bool> ConnectAsync()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            var connectionInputs = new
            {
                pgServer = settings["PGServer"].Value,
                pgDatabase = settings["PGDatabase"].Value,
                pgUsername = settings["PGUsername"].Value,
                pgPassword = settings["PGPassword"].Value
            };

            try
            {
                var response = await ApiClient.PostAsJsonAsync("connect", connectionInputs);
                response.EnsureSuccessStatusCode();
                IsConnected = true;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                IsConnected = false;
                return false;
            }
        }

        public static void ShowFailedConnection()
        {
            string messageBoxText = "Can not create connection, please check your settings.";
            string caption = "Failed connection";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBox.Show(messageBoxText, caption, button, icon);
        }

        public static void ShowLogoutFailed()
        {
            string messageBoxText = "Something went wrong, please try again later.";
            string caption = "Log out failed";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBox.Show(messageBoxText, caption, button, icon);
        }

        public static void ShowLoginFailed()
        {
            string messageBoxText = "You have entered wrong username or password.";
            string caption = "Login failed";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBox.Show(messageBoxText, caption, button, icon);
        }

        public static async Task<User?> LoginAsync(string username, string password)
        {
            var loginInputs = new
            {
                username = username,
                password = password,
            };

            try
            {
                var response = await ApiClient.PostAsJsonAsync("auth/login", loginInputs);
                response.EnsureSuccessStatusCode();
                User? user = await response.Content.ReadFromJsonAsync<User?>();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static async Task<bool> LogoutAsync()
        {
            try
            {
                var response = await ApiClient.PostAsync("auth/logout", null);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public static async Task<(List<Customer>, Paging)?> GetCustomersAsync(int limit = 100, int offset = 0)
        {        
            try
            {
                var response = await ApiClient.GetAsync($"customers?limit={limit}&offset={offset}");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadFromJsonAsync<ResponseData<Customer>?>();
                if (responseData != null)
                {
                    return (responseData.Data, responseData.Paging);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static async Task<(List<Category>, Paging)?> GetAllCategories(int limit = 100, int offset = 0)
        {
            try
            {
                var response = await ApiClient.GetAsync($"categories?limit={limit}&offset={offset}");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadFromJsonAsync<ResponseData<Category>?>();
                if (responseData != null)
                {
                    return (responseData.Data, responseData.Paging);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}

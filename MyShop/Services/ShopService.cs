using MyShop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
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
        public static async Task<(List<Customer>, Paging)?> searchCustomersAsync(int limit = 100, int offset = 0, string q = "")
        {
            try
            {
                var response = await ApiClient.GetAsync($"customers/search/?limit={limit}&offset={offset}&q={q}");
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
        public static async Task<(List<Product>, Paging)?> GetProductsAsync(int limit = 100, int offset = 0)
        {
            try
            {
                var response = await ApiClient.GetAsync($"products?limit={limit}&offset={offset}");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadFromJsonAsync<ResponseData<Product>>();
                var temp = 0;
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

        public static async Task<(List<Order>, Paging)?> GetOrdersAsync(int limit = 100, int offset = 0, DateTime startDate = default, DateTime endDate = default)
        {
            try
            {
                String url = $"orders?limit={limit}&offset={offset}";
                if (startDate!=default)
                {
                    url += $"&startDate={startDate.ToString().Split(' ')[0]}";
                }
                if (endDate!=default)
                {
                    url += $"&endDate={endDate.ToString().Split(' ')[0]}";
                }
                var response = await ApiClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadFromJsonAsync<ResponseData<Order>>();
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

        public static async Task<OrderDetail?> GetOrderDetailAsync(int orderId)
        {
            try
            {

                var response = await ApiClient.GetAsync($"orders/{orderId}");
                response.EnsureSuccessStatusCode();

                var responseData = await response.Content.ReadFromJsonAsync<ResponseObjectData<OrderDetail>>();
                if (responseData != null)
                {
                    return responseData.Data;

                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static async Task AddOrder(Object Order)
        {
            try
            {
                var x = JsonConvert.SerializeObject(Order);
                var response = await ApiClient.PostAsync("orders", new StringContent(JsonConvert.SerializeObject(Order), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadFromJsonAsync<ResponseData<Customer>?>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static async Task AddCustomer(Object customer)
        {
            try
            {
                var response = await ApiClient.PostAsync("customers", new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadFromJsonAsync<ResponseData<Customer>?>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static async Task<bool> DeleteCustomerAsync(int customerId)
        {
            try
            {
                var response = await ApiClient.DeleteAsync($"customers/{customerId}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public static async Task<bool> DeleteOrderAsync(int OrderId)
        {
            try
            {
                var response = await ApiClient.DeleteAsync($"orders/{OrderId}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public static async Task UpdateCustomer(Object customer,int CustomerId)
        {
            try
            {
                var response = await ApiClient.PutAsync($"customers/{CustomerId}", new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadFromJsonAsync<ResponseData<Customer>?>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static async Task UpdateOrder(Object orderDetail,int orderId)
        {
            try
            {
                var response = await ApiClient.PutAsync($"orders/{orderId}", new StringContent(JsonConvert.SerializeObject(orderDetail), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadFromJsonAsync<ResponseObjectData<OrderDetail>?>();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

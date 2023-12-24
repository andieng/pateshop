using Microsoft.Extensions.Hosting;
using MyShop.ViewModels;
using MyShop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
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

        public static async Task<(List<Product>, Paging)?> GetProductsOfCategory(int categoryId, int limit = 100, int offset = 0)
        {
            try
            {
                var response = await ApiClient.GetAsync($"categories/{categoryId}?limit={limit}&offset={offset}");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadFromJsonAsync<ResponseData<Product>?>();
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
      
        public static async Task<(List<Order>, Paging)?> GetOrdersAsync(int limit = 100, int offset = 0)
        {
            try
            {
                var response = await ApiClient.GetAsync($"orders?limit={limit}&offset={offset}");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadFromJsonAsync<ResponseData<Order>?>();
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

        public static async Task<Product?> GetProduct(int productId, int categoryId)
        {
            try
            {
                var response = await ApiClient.GetAsync($"categories/{categoryId}/products/{productId}");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadFromJsonAsync<Product?>();
                if (responseData != null)
                {
                    return responseData;
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

        public static async Task<bool> UpdateProduct(int categoryId, Product editedProduct)
        {
            var product = new
            {
                productId = editedProduct.ProductId,
                productName = editedProduct.ProductName,
                productSku = editedProduct.ProductSKU,
                categoryId = categoryId,
                description = editedProduct.Description,
                quantity = editedProduct.Quantity,
                price = editedProduct.Price,
                cost = editedProduct.Cost,
                image = editedProduct.Image,
                size = editedProduct.Size,
                color = editedProduct.Color,
            };

            try
            {
                var response = await ApiClient.PutAsJsonAsync($"categories/{categoryId}/products/{editedProduct.ProductId}", product);
                response.EnsureSuccessStatusCode();

                var responseData = await response.Content.ReadFromJsonAsync<ActionResponseData>();

                if (responseData != null && responseData.Error != null)
                {
                    MessageBox.Show($"Error: {responseData.Error}");
                    return false;
                }
                else
                {
                    MessageBox.Show("Update successful!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
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

        private static bool ValidateProductTypes(Product product)
        {
            return
                product.ProductId is int &&
                product.ProductName is string &&
                product.ProductSKU is string &&
                product.CategoryId is int &&
                product.Description is string &&
                product.Quantity is int &&
                product.Price is float &&
                product.Cost is float &&
                product.Size is float &&
                product.Color is string;
        }

        public static async Task<bool> AddProduct(Product newProduct)
        {
            var isValid = ValidateProductTypes(newProduct);

            if (!isValid)
            {
                MessageBox.Show("Invalid data types for product properties!");
                return false;
            }

            var product = new
            {
                productId = newProduct.ProductId,
                productName = newProduct.ProductName,
                productSku = newProduct.ProductSKU,
                categoryId = newProduct.CategoryId,
                description = newProduct.Description,
                quantity = newProduct.Quantity,
                price = newProduct.Price,
                cost = newProduct.Cost,
                image = newProduct.Image,
                size = newProduct.Size,
                color = newProduct.Color,
            };

            try
            {
                var response = await ApiClient.PostAsJsonAsync($"categories/{newProduct.CategoryId}/products", product);
                response.EnsureSuccessStatusCode();

                var responseData = await response.Content.ReadFromJsonAsync<ActionResponseData>();

                if (responseData != null && responseData.Error != null)
                {
                    MessageBox.Show($"Error: {responseData.Error}");
                    return false;
                }
                else
                {
                    MessageBox.Show("Add successful!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
      
        public static async Task<bool> DeleteCustomerAsync(int OrderId)
        {
            try
            {
                var response = await ApiClient.DeleteAsync($"customers/{OrderId}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public static async Task<bool> DeleteProduct(int productId, int categoryId)
        {
            try
            {
                var response = await ApiClient.DeleteAsync($"categories/{categoryId}/products/{productId}");
                response.EnsureSuccessStatusCode();

                var responseData = await response.Content.ReadFromJsonAsync<ActionResponseData>();

                if (responseData != null && responseData.Error != null)
                {
                    MessageBox.Show($"Error: {responseData.Error}");
                    return false;
                }
                else
                {
                    MessageBox.Show("Delete successful!");
                    return true;
                }
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
    }
}

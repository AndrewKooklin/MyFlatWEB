using MyFlatWEB.Areas.Management.Models.Rendering;
using MyFlatWEB.Data.Repositories.Abstract;
using MyFlatWEB.Models.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MyFlatWEB.Data.Repositories.API
{
    public class APIRenderingRepository : IRenderingRepository
    {
        private HttpClient _httpClient;
        private string url = @"https://localhost:44388/";
        string urlRequest = "";
        HttpResponseMessage response;
        bool apiResponseConvert;

        public List<OrderModel> GetAllOrders()
        {
            List<OrderModel> orders = new List<OrderModel>();
            urlRequest = $"{url}" + "OrdersAPI/GetAllOrders";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result =  _httpClient.GetStringAsync(urlRequest).Result;
                orders = JsonConvert.DeserializeObject<List<OrderModel>>(result);
            }

            return orders;
        }

        public List<OrderModel> GetOrdersByService(string serviceName)
        {
            List<OrderModel> orders = new List<OrderModel>();
            urlRequest = $"{url}" + "OrdersAPI/GetOrdersByService/" + $"{serviceName}";

            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string json = _httpClient.GetStringAsync(urlRequest).Result;
                orders = JsonConvert.DeserializeObject<List<OrderModel>>(json);
            }

            return orders;
        }

        public async Task<List<OrderModel>> GetOrdersByPeriod(PeriodModel model)
        {
            List<OrderModel> orders = new List<OrderModel>();
            urlRequest = $"{url}" + "OrdersAPI/GetOrdersByPeriod/" + $"{model}";

            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (String.IsNullOrEmpty(apiResponse))
                    {
                        return null;
                    }
                    orders = JsonConvert.DeserializeObject<List<OrderModel>>(apiResponse);
                }
            }

            return orders;
        }

        public List<string> GetServiceNames()
        {
            List<string> names = new List<string>();
            urlRequest = $"{url}" + "ServicesAPI/GetServiceNames";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                names = JsonConvert.DeserializeObject<List<string>>(result);
            }

            return names;
        }

        public List<string> GetStatusNames()
        {
            List<string> names = new List<string>();
            urlRequest = $"{url}" + "StatusesAPI/GetStatusNames";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                names = JsonConvert.DeserializeObject<List<string>>(result);
            }

            return names;
        }

        public List<ServiceOrdersCountModel> GetServiceOrdersCount()
        {
            List<ServiceOrdersCountModel> serviceOrdersCount = new List<ServiceOrdersCountModel>();
            urlRequest = $"{url}" + "ServicesAPI/GetServiceOrdersCount";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                serviceOrdersCount = JsonConvert.DeserializeObject<List<ServiceOrdersCountModel>>(result);
            }

            return serviceOrdersCount;
        }

        public async Task<bool> SaveOrder(OrderModel order)
        {
            urlRequest = $"{url}" + "OrdersAPI/SaveOrder/" + $"{order}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, order))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseConvert = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseConvert;
        }

        public async Task<bool> ChangeStatusOrder(ChangeStatusModel model)
        {
            urlRequest = $"{url}" + "StatusesAPI/ChangeStatusOrder/" + $"{model}";

            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await _httpClient.PostAsJsonAsync(urlRequest, model);
            }

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

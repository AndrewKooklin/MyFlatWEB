using MyFlatWEB.Areas.Management.Models.Rendering;
using MyFlatWEB.Data.Repositories.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        string result;
        bool apiResponseConvert;


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
    }
}

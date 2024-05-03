using MyFlatWEB.Areas.Management.Models.EditPages;
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
    public class APIPageEditorRepository : IPageEditorRepository
    {
        private HttpClient _httpClient;
        private string url = @"https://localhost:44388/";
        string urlRequest = "";
        HttpResponseMessage response;
        string result;
        bool apiResponseConvert;

        public HomePagePlaceholderModel GetHomePagePlaceholder()
        {
            HomePagePlaceholderModel phm = new HomePagePlaceholderModel();

            urlRequest = $"{url}" + "HomePageEditAPI/GetHomePagePlaceholder";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                phm = JsonConvert.DeserializeObject<HomePagePlaceholderModel>(result);
            }

            return phm;
        }
    }
}

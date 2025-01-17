using MyFlatWEB.Areas.Management.Models.EditPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MyFlatWEB.HelpMethods
{
    public class TopMenu
    {
        private HttpClient _httpClient;
        private string url = @"https://localhost:44388/";
        private string urlRequest = "";
        private HttpResponseMessage response;
        private string apiResponse;
        private bool apiResponseBoolean;

        public List<TopMenuLinkNameModel> GetTopLinks()
        {
            List<TopMenuLinkNameModel> topLinks = new List<TopMenuLinkNameModel>();

            urlRequest = $"{url}" + "HomePageEditAPI/GetTopMenuLinkNames";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                topLinks = JsonConvert.DeserializeObject<List<TopMenuLinkNameModel>>(result);
            }

            return topLinks;
        }
    }
}

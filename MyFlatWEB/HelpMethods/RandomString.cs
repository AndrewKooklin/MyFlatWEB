using MyFlatWEB.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MyFlatWEB.HelpMethods
{
    public class RandomString
    {
        private HttpClient _httpClient;
        private string url = @"https://localhost:44388/";
        private string urlRequest = "";

        public List<string> GetPhraseNames()
        {
            List<string> phraseNames = new List<string>();

            urlRequest = $"{url}" + "HomePageEditAPI/GetRandomPhraseNames";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                phraseNames = JsonConvert.DeserializeObject<List<string>>(result);
            }

            return phraseNames;
        }
        public string GetHeaderString()
        {
            string[] Titles = GetPhraseNames().ToArray();
            //{
            //    "BUILD YOU FLAT!",
            //    "GOOD HOUSE!",
            //    "THE BEST SERVICE",
            //    "EXCELLENT QUALITY",
            //    "EXCELLENT JOB",
            //    "LIVE COMFORTABLY",
            //    "ECO-FRIENDLY HOUSES",
            //    "SMART CONSTRUCTION"
            //};

            return Titles[new Random().Next(0, Titles.Length)];
        }
    }
}

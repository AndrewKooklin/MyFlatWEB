﻿using Microsoft.AspNetCore.Identity;
using MyFlatWEB.Data.Repositories.Abstract;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MyFlatWEB.Areas.Management.Models.Users;
using MyFlatWEB.Models.Account;

namespace MyFlatWEB.Data.Repositories.API
{
    public class APIAccountRepository : IAccountRepository
    {
        private HttpClient _httpClient;
        private string url = @"https://localhost:44388/";
        private string urlRequest = "";
        private HttpResponseMessage response;
        private string apiResponse;
        private bool apiResponseBoolean;

        private List<string> userRoles;
        private List<string> roleNames;
        private IdentityRole role;
        private IEnumerable<IdentityRole> roles;
        private List<IdentityUser> users;
        private UserWithRolesModel userWithRoles;

        public APIAccountRepository()
        {
        }

        public async Task<bool> CheckUserToDB(LoginModel model)
        {
            urlRequest = $"{url}" + "LoginAPI/CheckUserToDB/" + $"{model}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseBoolean;
        }

        public async Task<bool> CreateUser(RegisterModel model)
        {
            urlRequest = $"{url}" + "RegisterAPI/CreateUser/" + $"{model}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseBoolean;
        }

        public async Task<bool> AddNewUser(AddUserModel model)
        {
            urlRequest = $"{url}" + "UsersAPI/AddNewUser/" + $"{model}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseBoolean;
        }

        public List<string> GetRoleNames()
        {
            roleNames = new List<string>();
            urlRequest = $"{url}" + "RegisterAPI/GetRoleNames";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                roleNames = JsonConvert.DeserializeObject<List<string>>(result);
            }

            return roleNames;
        }

        public IEnumerable<IdentityRole> GetRoles()
        {
            urlRequest = $"{url}" + "RolesAPI/GetRoles";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                roles = JsonConvert.DeserializeObject<IEnumerable<IdentityRole>>(result);
            }

            return roles;
        }

        public IdentityRole GetRoleById(string id)
        {
            urlRequest = $"{url}" + "RolesAPI/GetRoleById/" + $"{id}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                role = JsonConvert.DeserializeObject<IdentityRole>(result);
            }

            return role;
        }

        public async Task<List<string>> GetUserRoles(LoginModel model)
        {
            urlRequest = $"{url}" + "LoginAPI/GetUserRoles/" + $"{model}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    userRoles = JsonConvert.DeserializeObject<List<string>>(apiResponse);
                }
            }

            return userRoles;
        }

        public async Task<bool> CreateRole(IdentityRole role)
        {
            urlRequest = $"{url}" + "RolesAPI/CreateRole/" + $"{role}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, role))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseBoolean;
        }



        public async Task<bool> DeleteRole(string id)
        {
            urlRequest = $"{url}" + "RolesAPI/DeleteRole/" + $"{id}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, id))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseBoolean;
        }

        public List<IdentityUser> GetUsers()
        {
            urlRequest = $"{url}" + "UsersAPI/GetUsers";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                users = JsonConvert.DeserializeObject<List<IdentityUser>>(result);
            }

            return users;
        }

        public UserWithRolesModel GetUserWithRoles(string id)
        {
            urlRequest = $"{url}" + "UsersAPI/GetUserWithRoles/" + $"{id}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                userWithRoles = JsonConvert.DeserializeObject<UserWithRolesModel>(result);
            }

            return userWithRoles;
        }

        public async Task<bool> AddRoleToUser(RoleUserModel model)
        {
            urlRequest = $"{url}" + "UsersAPI/AddRoleToUser/" + $"{model}/";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseBoolean;
        }

        public async Task<bool> DeleteRoleUser(RoleUserModel model)
        {
            urlRequest = $"{url}" + "UsersAPI/DeleteRoleUser/" + $"{model}/";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseBoolean;
        }

        public async void LogoutUser()
        {
            urlRequest = $"{url}" + "LogoutAPI/LogoutUser";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                await _httpClient.GetAsync(urlRequest);
            }
        }

        public async Task<bool> DeleteRolesUser(string id)
        {
            urlRequest = $"{url}" + "UsersAPI/DeleteRolesUser/" + $"{id}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, id))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseBoolean;
        }

        public async Task<bool> DeleteUser(string id)
        {
            urlRequest = $"{url}" + "UsersAPI/DeleteUser/" + $"{id}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, id))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseBoolean;
        }
    }
}

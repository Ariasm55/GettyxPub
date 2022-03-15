
using GettyX.Web.Interfaces;
using Getty.Core.DTOs;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace GettyX.Web.Services
{
    public class UserService : IUsersService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localstorage;
        private readonly AuthenticationStateProvider _auth;
        public UserService(HttpClient httpClient,
                            ILocalStorageService localStorage,
                            AuthenticationStateProvider auth)
        {
            _httpClient = httpClient;
            _localstorage = localStorage;
            _auth = auth;
        }

        public async Task<bool> Authentication(UserLoginDTO userModel)
        {
                        
            //getting response
            var result = await _httpClient.PostAsJsonAsync("/api/auth/login", userModel);
            

            if (result.IsSuccessStatusCode)
            {
                var token = await result.Content.ReadAsStringAsync();
                await _localstorage.SetItemAsync("0115", token);
                await _auth.GetAuthenticationStateAsync();

                return true;
            }
            else
            {
                return false;
            }
            

        }

        public async Task<bool> LogOut()
        {
            await _localstorage.ClearAsync();
            await _auth.GetAuthenticationStateAsync();
            return true;
        }

    }
}

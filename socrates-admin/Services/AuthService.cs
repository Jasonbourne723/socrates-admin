using AntDesign;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Models.Request;
using Models.Response;
using System.Net.Http.Json;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IMessageService _messageService;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorageService;

        public AuthService(HttpClient httpClient, IMessageService messageService, NavigationManager navigationManager, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _messageService = messageService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Register(RegisterDto dto)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync("/api/auth/register", dto);
            var result = await httpResponseMessage.Content.ReadFromJsonAsync<Result<TokenDto>>();
            if (result.error_code != 0)
            {
                await _messageService.Error($"注册失败：{result.message}");
            }
            else
            {
                await _messageService.Success("注册成功");
                await _localStorageService.SetItemAsync("token", result.data);
                _navigationManager.NavigateTo("/");
            }
        }

        public async Task Login(LoginDto dto)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync("/api/auth/login", dto);
            var result = await httpResponseMessage.Content.ReadFromJsonAsync<Result<TokenDto>>();
            if (result.error_code != 0)
            {
                await _messageService.Error($"登录失败：{result.message}");
            }
            else
            {
                await _messageService.Success("登录成功");
                await _localStorageService.SetItemAsync("token", result.data);
                await GetLoginUser(result.data.access_token);
                _navigationManager.NavigateTo("/");
            }
        }

        public async Task GitHubLogin(string code)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync($"/api/auth/github_login", new GitHubLoginDto { code = code });
            var result = await httpResponseMessage.Content.ReadFromJsonAsync<Result<TokenDto>>();
            if (result.error_code != 0)
            {
                await _messageService.Error($"登录失败：{result.message}");
            }
            else
            {
                await _messageService.Success("登录成功");
                await _localStorageService.SetItemAsync("token", result.data);
                await GetLoginUser(result.data.access_token);
                _navigationManager.NavigateTo("/");
            }
        }


        public async Task Logout()
        {
            await _localStorageService.RemoveItemAsync("token");
            await _localStorageService.RemoveItemAsync("current_user");
            var httpResponseMessage = await _httpClient.PostAsync($"/api/auth/logout", null);
            _navigationManager.NavigateTo("/login");
        }

        private async Task GetLoginUser(string token)
        {
            var loginUserResult = await _httpClient.GetFromJsonAsync<Result<LoginUserDto>>($"/api/auth/info");
            await _localStorageService.SetItemAsync("current_user", loginUserResult.data);
        }




    }

}

using AntDesign;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Models.Request;
using Models.Response;
using System.Net.Http.Json;
using Result = Models.Response.Result;

namespace Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly HttpClient _httpClient;
        private string _path;

        public OrganizationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _path = $"/api/organization";
        }

        public async Task<Result<List<OrganizationNodeDto>>?> List()
        {
            return await _httpClient.GetFromJsonAsync<Result<List<OrganizationNodeDto>>>(_path);
        }

        public async Task<Result<OrganizationDto>?> Create(CreateOrganizationDto dto)
        {
            var resposneMessage = await _httpClient.PostAsJsonAsync(_path, dto);
            return await resposneMessage.Content.ReadFromJsonAsync<Result<OrganizationDto>>();
        }

        public async Task<Result<OrganizationDto>?> Update(UpdateOrganizationDto dto)
        {
            var resposneMessage = await _httpClient.PutAsJsonAsync(_path, dto);
            return await resposneMessage.Content.ReadFromJsonAsync<Result<OrganizationDto>>();
        }

        public async Task<Result?> Delete(long id)
        {
            var resposneMessage = await _httpClient.DeleteAsync($"{_path}/{id}");
            return await resposneMessage.Content.ReadFromJsonAsync<Result>();
        }
    }

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
                _navigationManager.NavigateTo("/", true);
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
                _navigationManager.NavigateTo("/", true);
            }
        }
    }

}

using AntDesign;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Models.Response;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using Result = Models.Response.Result;

namespace Extensions
{
    public class CustomHttpClientHandler : DelegatingHandler
    {
        private readonly IMessageService _messageService;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorageService;

        public CustomHttpClientHandler(IMessageService messageService, NavigationManager navigationManager, ILocalStorageService localStorageService)
        {
            _messageService = messageService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // 在这里可以处理请求，例如添加认证信息或日志记录
            Console.WriteLine($"Request: {request.Method} {request.RequestUri}");

            if (!request.Headers.Contains("Authorization"))
            {
                var tokenDto = await _localStorageService.GetItemAsync<TokenDto>("token");
                if (tokenDto != null)
                {
                    request.Headers.Add("Authorization", $"{tokenDto.token_type} {tokenDto.access_token}");
                }
            }

            // 调用基础的 SendAsync 方法发送请求
            try
            {
                var response = await base.SendAsync(request, cancellationToken);

                //// 在这里处理响应，例如统一错误处理
                //if (!response.IsSuccessStatusCode)
                //{
                //    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                //    {
                //        _navigationManager.NavigateTo("/login", true);
                //    }
                //    else
                //    {
                //        await _messageService.Error($"接口访问失败：{response.StatusCode}");
                //    }
                //}
                return response;
            }
            catch (HttpRequestException ex)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable); // 返回一个有效响应，避免 null
            }
            catch (TaskCanceledException ex)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.RequestTimeout);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }

        }
    }


    public class CustomHttpClient : ICustomHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMessageService _messageService;
        private readonly NavigationManager _navigationManager;

        public CustomHttpClient(HttpClient httpClient, IMessageService messageService,NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _messageService = messageService;
            _navigationManager = navigationManager;
        }

        public async Task<T> GetAndHandleBusinessErrorAsync<T>(string requestUri)
        {
            var response = await _httpClient.GetAsync(requestUri);
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    _navigationManager.NavigateTo("/login", true);
                }
                else
                {
                    await _messageService.Error($"接口故障,{requestUri},{response.StatusCode}");
                    return default(T);
                }
               
            }
            if (typeof(T) == typeof(Result))
            {
                var result = await response.Content.ReadFromJsonAsync<T>();

                var res = result as Result;
                if (res!.error_code != 0)
                {
                    await _messageService.Error($"接口返回失败,{requestUri},{res.message}");
                }
                return result;
            }
            else
            {
                var result = await response.Content.ReadFromJsonAsync<Result<T>>();

                if (result!.error_code != 0)
                {
                    await _messageService.Error($"接口返回失败,{requestUri},{result.message}");
                }
                return result.data;
            }
        }
    }

}

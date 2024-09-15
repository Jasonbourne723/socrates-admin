using AntDesign;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Models.Response;

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

                // 在这里处理响应，例如统一错误处理
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        _navigationManager.NavigateTo("/login", true);
                    }
                    else
                    {
                        await _messageService.Error($"接口访问失败：{response.StatusCode}");
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                await _messageService.Error($"服务器连接失败");
                return null;
            }

        }
    }
}

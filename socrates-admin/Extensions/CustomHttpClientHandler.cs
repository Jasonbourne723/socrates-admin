using AntDesign;
using Microsoft.AspNetCore.Components;

namespace Extensions
{
    public class CustomHttpClientHandler : DelegatingHandler
    {
        private readonly IMessageService _messageService;
        private readonly NavigationManager _navigationManager;

        public CustomHttpClientHandler(IMessageService messageService, NavigationManager navigationManager)
        {
            _messageService = messageService;
            _navigationManager = navigationManager;
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _navigationManager.NavigateTo("/login", true);
            // 在这里可以处理请求，例如添加认证信息或日志记录
            Console.WriteLine($"Request: {request.Method} {request.RequestUri}");
            // 调用基础的 SendAsync 方法发送请求
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
    }
}

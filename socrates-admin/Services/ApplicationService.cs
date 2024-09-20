using Extensions;
using Models.Request;
using Models.Response;
using System.IO;
using System.Net.Http.Json;

namespace Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly HttpClient _httpClient;
        private readonly ICustomHttpClient _customHttpClient;
        private readonly string _path = "/api/application";

        public ApplicationService(HttpClient httpClient,
                                  ICustomHttpClient customHttpClient)
        {
            _httpClient = httpClient;
            _customHttpClient = customHttpClient;
        }

        public async Task<List<ApplicationDto>?> List()
        {
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<List<ApplicationDto>>(_path);
        }

        public async Task<PageList<ApplicationDto>?> PageList(int pageIndex, int pageSize)
        {
            var path = $"{_path}/pagelist?page_index={pageIndex}&page_size={pageSize}";
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<PageList<ApplicationDto>>(path);
        }

        public async Task<Result<ApplicationDto>?> Create(CreateApplicationDto dto)
        {
            var resposneMessage = await _httpClient.PostAsJsonAsync(_path, dto);
            return await resposneMessage.Content.ReadFromJsonAsync<Result<ApplicationDto>>();
        }

        public async Task<Result<ApplicationDto>?> Update(UpdateApplicationDto dto)
        {
            var resposneMessage = await _httpClient.PutAsJsonAsync(_path, dto);
            return await resposneMessage.Content.ReadFromJsonAsync<Result<ApplicationDto>>();
        }

        public async Task<Result?> Delete(long roleId)
        {
            var path = $"{_path}/{roleId}";
            var resposneMessage = await _httpClient.DeleteAsync(path);
            return await resposneMessage.Content.ReadFromJsonAsync<Result>();
        }
    }

}

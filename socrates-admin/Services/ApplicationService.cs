using Models.Request;
using Models.Response;
using System.IO;
using System.Net.Http.Json;

namespace Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _path = "/api/application";

        public ApplicationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<List<ApplicationDto>>?> List()
        {
            return await _httpClient.GetFromJsonAsync<Result<List<ApplicationDto>>>(_path);
        }

        public async Task<Result<PageList<ApplicationDto>>?> PageList(int pageIndex, int pageSize)
        {
            var path = $"{_path}/pagelist?page_index={pageIndex}&page_size={pageSize}";
            return await _httpClient.GetFromJsonAsync<Result<PageList<ApplicationDto>>>(path);
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

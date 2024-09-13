using Models.Request;
using Models.Response;
using System.Net.Http.Json;

namespace Services
{
    public class PermissionSpaceService : IPermissionSpaceService
    {
        private readonly HttpClient _httpClient;
        private string _path;

        public PermissionSpaceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _path = "/api/permission_space";
        }


        public async Task<Result<PermissionSpaceDto>> Create(CreatePermissionSpaceDto dto)
        {
            var resposneMessage = await _httpClient.PostAsJsonAsync(_path, dto);
            return await resposneMessage.Content.ReadFromJsonAsync<Result<PermissionSpaceDto>>();
        }

        public async Task<Result<PermissionSpaceDto>> Update(UpdatePermissionSpaceDto dto)
        {
            var resposneMessage = await _httpClient.PutAsJsonAsync(_path, dto);
            return await resposneMessage.Content.ReadFromJsonAsync<Result<PermissionSpaceDto>>();
        }

        public async Task<Result> Delete(long id)
        {
            var responseMesage = await _httpClient.DeleteAsync($"{_path}/{id}");
            return await responseMesage.Content.ReadFromJsonAsync<Result>();
        }

        public async Task<Result<List<PermissionSpaceDto>>> List()
        {
            return await _httpClient.GetFromJsonAsync<Result<List<PermissionSpaceDto>>>(_path);
        }

        public async Task<Result<PageList<PermissionSpaceDto>>> PageList(int pageIndex, int pageSize)
        {
            var path = $"{_path}/pagelist?page_index={pageIndex}&page_size={pageSize}";
            return await _httpClient.GetFromJsonAsync<Result<PageList<PermissionSpaceDto>>>(path);
        }
    }
}

using Extensions;
using Models.Request;
using Models.Response;
using System.Net.Http.Json;

namespace Services
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _httpClient;
        private readonly ICustomHttpClient _customHttpClient;
        private string _path;

        public RoleService(HttpClient httpClient,ICustomHttpClient customHttpClient)
        {
            _httpClient = httpClient;
            _customHttpClient = customHttpClient;
            _path = $"/api/role";
        }

        public async Task<Result<PageList<RoleDto>>?> PageList(int pageIndex, int pageSize)
        {
            var path = $"{_path}/pagelist?page_index={pageIndex}&page_size={pageSize}";
            return await _httpClient.GetFromJsonAsync<Result<PageList<RoleDto>>>(path);
        }

        public async Task<List<RoleDto>?> List()
        {
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<List<RoleDto>>(_path);
        }

        public async Task<Result<RoleDto>?> Create(CreateRoleDto dto)
        {
            var resposneMessage = await _httpClient.PostAsJsonAsync(_path, dto);
            return await resposneMessage.Content.ReadFromJsonAsync<Result<RoleDto>>();
        }

        public async Task<Result<RoleDto>?> Update(UpdateRoleDto dto)
        {
            var resposneMessage = await _httpClient.PutAsJsonAsync(_path, dto);
            return await resposneMessage.Content.ReadFromJsonAsync<Result<RoleDto>>();
        }

        public async Task<Result?> Delete(long roleId)
        {
            var path = $"{_path}/{roleId}";
            var resposneMessage = await _httpClient.DeleteAsync(path);
            return await resposneMessage.Content.ReadFromJsonAsync<Result>();
        }
    }

}

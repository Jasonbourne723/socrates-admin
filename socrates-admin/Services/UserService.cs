using Models.Request;
using Models.Response;
using System.Net.Http.Json;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _path = "/api/user";

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<List<UserDto>>?> List()
        {
            return await _httpClient.GetFromJsonAsync<Result<List<UserDto>>>(_path);
        }

        public async Task<Result<PageList<UserDto>>?> PageList(int pageIndex, int pageSize)
        {
            var path = $"{_path}/pagelist?page_index={pageIndex}&page_size={pageSize}";
            return await _httpClient.GetFromJsonAsync<Result<PageList<UserDto>>>(path);
        }

        public async Task<Result<UserDto>?> Create(CreateUserDto dto)
        {
            var resposneMessage = await _httpClient.PostAsJsonAsync(_path, dto);
            return await resposneMessage.Content.ReadFromJsonAsync<Result<UserDto>>();
        }

        public async Task<Result<UserDto>?> Update(UpdateUserDto dto)
        {
            var resposneMessage = await _httpClient.PutAsJsonAsync(_path, dto);
            return await resposneMessage.Content.ReadFromJsonAsync<Result<UserDto>>();
        }

        public async Task<Result?> Delete(long roleId)
        {
            var path = $"{_path}/{roleId}";
            var resposneMessage = await _httpClient.DeleteAsync(path);
            return await resposneMessage.Content.ReadFromJsonAsync<Result>();
        }
    }

}

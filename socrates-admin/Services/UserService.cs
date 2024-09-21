using Extensions;
using Models.Request;
using Models.Response;
using System.IO;
using System.Net.Http.Json;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly string _path = "/api/user";
        private readonly ICustomHttpClient _customHttpClient;

        public UserService(ICustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<List<UserDto>?> List()
        {
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<List<UserDto>>(_path);
        }

        public async Task<PageList<UserDto>?> PageList(int pageIndex, int pageSize)
        {
            var path = $"{_path}/pagelist?page_index={pageIndex}&page_size={pageSize}";
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<PageList<UserDto>>(path);
        }

        public async Task<UserDto?> Create(CreateUserDto dto)
        {
            return await _customHttpClient.PostAndHandleBusinessErrorAsync<CreateUserDto, UserDto>(_path, dto);
        }

        public async Task<UserDto?> Update(UpdateUserDto dto)
        {
            return await _customHttpClient.PutAndHandleBusinessErrorAsync<UpdateUserDto, UserDto>(_path, dto);
        }

        public async Task Delete(long roleId)
        {
            var path = $"{_path}/{roleId}";
            await _customHttpClient.DeleteAndHandleBusinessErrorAsync(path);
        }
    }

}

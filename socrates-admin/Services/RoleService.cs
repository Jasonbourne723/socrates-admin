using Extensions;
using Models.Request;
using Models.Response;
using System.IO;
using System.Net.Http.Json;

namespace Services
{
    public class RoleService : IRoleService
    {
        private readonly ICustomHttpClient _customHttpClient;
        private string _path;

        public RoleService(ICustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
            _path = $"/api/role";
        }

        public async Task<PageList<RoleDto>?> PageList(int pageIndex, int pageSize)
        {
            var path = $"{_path}/pagelist?page_index={pageIndex}&page_size={pageSize}";
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<PageList<RoleDto>>(path);
        }

        public async Task<List<RoleDto>?> List()
        {
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<List<RoleDto>>(_path);
        }

        public async Task<RoleDto?> Create(CreateRoleDto dto)
        {
            return await _customHttpClient.PostAndHandleBusinessErrorAsync<CreateRoleDto, RoleDto>(_path, dto);
        }

        public async Task<RoleDto?> Update(UpdateRoleDto dto)
        {
            return await _customHttpClient.PutAndHandleBusinessErrorAsync<UpdateRoleDto, RoleDto>(_path, dto);
        }

        public async Task Delete(long roleId)
        {
            var path = $"{_path}/{roleId}";
            await _customHttpClient.DeleteAndHandleBusinessErrorAsync(path);
        }
    }

}

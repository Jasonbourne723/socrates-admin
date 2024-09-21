using Extensions;
using Models.Request;
using Models.Response;
using System.Net.Http.Json;

namespace Services
{
    public class PermissionSpaceService : IPermissionSpaceService
    {
        private readonly ICustomHttpClient _customHttpClient;
        private string _path;

        public PermissionSpaceService(ICustomHttpClient customHttpClient)
        {
            _path = "/api/permission_space";
            _customHttpClient = customHttpClient;
        }


        public async Task<PermissionSpaceDto> Create(CreatePermissionSpaceDto dto)
        {
            return await _customHttpClient.PostAndHandleBusinessErrorAsync<CreatePermissionSpaceDto, PermissionSpaceDto>(_path, dto);
        }

        public async Task<PermissionSpaceDto> Update(UpdatePermissionSpaceDto dto)
        {
            return await _customHttpClient.PutAndHandleBusinessErrorAsync<UpdatePermissionSpaceDto, PermissionSpaceDto>(_path, dto);
        }

        public async Task Delete(long id)
        {
            await _customHttpClient.DeleteAndHandleBusinessErrorAsync($"{_path}/{id}");
        }

        public async Task<List<PermissionSpaceDto>> List()
        {
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<List<PermissionSpaceDto>>(_path);
        }

        public async Task<PageList<PermissionSpaceDto>> PageList(int pageIndex, int pageSize)
        {
            var path = $"{_path}/pagelist?page_index={pageIndex}&page_size={pageSize}";
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<PageList<PermissionSpaceDto>>(path);
        }
    }
}

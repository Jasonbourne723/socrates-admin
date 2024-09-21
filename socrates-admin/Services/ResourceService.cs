using Extensions;
using Models.Request;
using Models.Response;
using System.IO;
using System.Net.Http.Json;

namespace Services
{
    public class ResourceService : IResourceService
    {
        private readonly ICustomHttpClient _customHttpClient;
        private string _path;

        public ResourceService(ICustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
            _path = $"/api/resource";
        }

        public async Task<PageList<ResourceDto>?> PageList(int pageIndex, int pageSize)
        {
            var path = $"{_path}/pagelist?page_index={pageIndex}&page_size={pageSize}";
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<PageList<ResourceDto>>(path);
        }

        public async Task<List<ResourceDto>?> List()
        {
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<List<ResourceDto>>(_path);
        }

        public async Task<ResourceDto?> Create(CreateResourceDto dto)
        {
            return await _customHttpClient.PostAndHandleBusinessErrorAsync<CreateResourceDto, ResourceDto>(_path, dto);
        }

        public async Task<ResourceDto?> Update(UpdateResourceDto dto)
        {
            return await _customHttpClient.PutAndHandleBusinessErrorAsync<UpdateResourceDto, ResourceDto>(_path, dto);
        }

        public async Task Delete(long ResourceId)
        {
            var path = $"{_path}/{ResourceId}";
            await _customHttpClient.DeleteAndHandleBusinessErrorAsync(path);
        }

        public async Task<ResourceDto> GetOne(long ResourceId)
        {
            var path = $"{_path}/{ResourceId}";
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<ResourceDto>(path);
        }
    }

}

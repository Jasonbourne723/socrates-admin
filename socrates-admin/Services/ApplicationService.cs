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

        public async Task<ApplicationDto> Create(CreateApplicationDto dto)
        {
            return await _customHttpClient.PostAndHandleBusinessErrorAsync<CreateApplicationDto, ApplicationDto>(_path, dto);
        }

        public async Task Delete(long roleId)
        {
            var path = $"{_path}/{roleId}";
            await _customHttpClient.DeleteAndHandleBusinessErrorAsync(path);
        }

        public async Task<ApplicationDto?> Update(UpdateApplicationDto dto)
        {
            return await _customHttpClient.PutAndHandleBusinessErrorAsync<UpdateApplicationDto, ApplicationDto>(_path, dto);
        }
    }

}

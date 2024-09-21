using Extensions;
using Models.Request;
using Models.Response;
using System.Net.Http;
using System.Net.Http.Json;
using Result = Models.Response.Result;

namespace Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly ICustomHttpClient _customHttpClient;
        private string _path;

        public OrganizationService(ICustomHttpClient customHttpClient)
        {
            _path = $"/api/organization";
            _customHttpClient = customHttpClient;
        }

        public async Task<List<OrganizationNodeDto>?> All()
        {

            return await _customHttpClient.GetAndHandleBusinessErrorAsync<List<OrganizationNodeDto>>($"{_path}/all");
        }

        public async Task<OrganizationDto?> Create(CreateOrganizationDto dto)
        {
            return await _customHttpClient.PostAndHandleBusinessErrorAsync<CreateOrganizationDto, OrganizationDto>(_path, dto);
        }

        public async Task<OrganizationDto?> Update(UpdateOrganizationDto dto)
        {
            return await _customHttpClient.PutAndHandleBusinessErrorAsync<UpdateOrganizationDto, OrganizationDto>(_path, dto);
        }

        public async Task Delete(long id)
        {
            await _customHttpClient.DeleteAndHandleBusinessErrorAsync($"{_path}/{id}");
        }

        public async Task<List<OrganizationDto>?> List()
        {
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<List<OrganizationDto>>(_path);
        }
    }

}

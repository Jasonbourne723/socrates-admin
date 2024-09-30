using Extensions;
using Models.Request;
using Models.Response;

namespace Services
{
    public class PolicyService : IPolicyService
    {
        private readonly ICustomHttpClient _customHttpClient;
        private string _path;

        public PolicyService(ICustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
            _path = $"/api/policy";
        }

        public async Task<PageList<PolicyDto>?> PageList(int pageIndex, int pageSize)
        {
            var path = $"{_path}/pagelist?page_index={pageIndex}&page_size={pageSize}";
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<PageList<PolicyDto>>(path);
        }

        public async Task<List<PolicyDto>?> List()
        {
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<List<PolicyDto>>(_path);
        }

        public async Task<PolicyDto?> Create(CreatePolicyDto dto)
        {
            return await _customHttpClient.PostAndHandleBusinessErrorAsync<CreatePolicyDto, PolicyDto>(_path, dto);
        }

        public async Task<PolicyDto?> Update(UpdatePolicyDto dto)
        {
            return await _customHttpClient.PutAndHandleBusinessErrorAsync<UpdatePolicyDto, PolicyDto>(_path, dto);
        }

        public async Task Delete(long policyId)
        {
            var path = $"{_path}/{policyId}";
            await _customHttpClient.DeleteAndHandleBusinessErrorAsync(path);
        }
    }

}

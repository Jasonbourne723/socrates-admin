using Models.Request;
using Models.Response;

namespace Services
{
    public interface IPolicyService
    {
        Task<PolicyDto?> Create(CreatePolicyDto dto);
        Task Delete(long policyId);
        Task<List<PolicyDto>?> List();
        Task<PageList<PolicyDto>?> PageList(int pageIndex, int pageSize);
        Task<PolicyDto?> Update(UpdatePolicyDto dto);
    }
}
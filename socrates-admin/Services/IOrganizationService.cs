using Models.Request;
using Models.Response;

namespace Services
{
    public interface IOrganizationService
    {
        Task<Result<OrganizationDto>?> Create(CreateOrganizationDto dto);
        Task<Result?> Delete(long id);
        Task<Result<List<OrganizationNodeDto>>?> All();
        Task<Result<OrganizationDto>?> Update(UpdateOrganizationDto dto);
        Task<Result<List<OrganizationDto>>?> List();
    }
}
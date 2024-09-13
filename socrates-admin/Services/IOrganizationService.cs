using Models.Request;
using Models.Response;

namespace Services
{
    public interface IOrganizationService
    {
        Task<Result<OrganizationDto>?> Create(CreateOrganizationDto dto);
        Task<Result?> Delete(long id);
        Task<Result<List<OrganizationNodeDto>>?> List();
        Task<Result<OrganizationDto>?> Update(UpdateOrganizationDto dto);
    }
}
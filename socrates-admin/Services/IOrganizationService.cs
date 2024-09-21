using Models.Request;
using Models.Response;

namespace Services
{
    public interface IOrganizationService
    {
        Task<OrganizationDto?> Create(CreateOrganizationDto dto);
        Task Delete(long id);
        Task<List<OrganizationNodeDto>?> All();
        Task<OrganizationDto?> Update(UpdateOrganizationDto dto);
        Task<List<OrganizationDto>?> List();
    }
}
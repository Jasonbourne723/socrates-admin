using Models.Request;
using Models.Response;

namespace Services
{
    public interface IApplicationService
    {
        Task<ApplicationDto> Create(CreateApplicationDto dto);
        Task Delete(long roleId);
        Task<List<ApplicationDto>?> List();
        Task<PageList<ApplicationDto>?> PageList(int pageIndex, int pageSize);
        Task<ApplicationDto?> Update(UpdateApplicationDto dto);
    }
}
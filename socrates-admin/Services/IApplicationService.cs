using Models.Request;
using Models.Response;

namespace Services
{
    public interface IApplicationService
    {
        Task<Result<ApplicationDto>?> Create(CreateApplicationDto dto);
        Task<Result?> Delete(long roleId);
        Task<List<ApplicationDto>?> List();
        Task<PageList<ApplicationDto>?> PageList(int pageIndex, int pageSize);
        Task<Result<ApplicationDto>?> Update(UpdateApplicationDto dto);
    }
}
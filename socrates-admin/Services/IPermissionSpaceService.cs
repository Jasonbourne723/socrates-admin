using Models.Request;
using Models.Response;

namespace Services
{
    public interface IPermissionSpaceService
    {
        Task<PermissionSpaceDto> Create(CreatePermissionSpaceDto dto);
        Task Delete(long id);
        Task<List<PermissionSpaceDto>> List();
        Task<PageList<PermissionSpaceDto>> PageList(int pageIndex, int pageSize);
        Task<PermissionSpaceDto> Update(UpdatePermissionSpaceDto dto);
    }
}
using Models.Request;
using Models.Response;

namespace Services
{
    public interface IPermissionSpaceService
    {
        Task<Result<PermissionSpaceDto>> Create(CreatePermissionSpaceDto dto);
        Task<Result> Delete(long id);
        Task<Result<List<PermissionSpaceDto>>> List();
        Task<Result<PageList<PermissionSpaceDto>>> PageList(int pageIndex, int pageSize);
        Task<Result<PermissionSpaceDto>> Update(UpdatePermissionSpaceDto dto);
    }
}
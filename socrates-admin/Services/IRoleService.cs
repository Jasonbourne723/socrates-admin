using Models.Request;
using Models.Response;

namespace Services
{
    public interface IRoleService
    {
        Task<Result<RoleDto>?> Create(CraeteRoleDto dto);
        Task<Result?> Delete(long roleId);
        Task<Result<PageList<RoleDto>>?> PageList(int pageIndex, int pageSize);
        Task<Result<RoleDto>?> Update(UpdateRoleDto dto);
    }
}
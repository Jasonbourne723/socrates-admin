using Models.Request;
using Models.Response;

namespace Services
{
    public interface IRoleService
    {
        Task<Result<RoleDto>?> Create(CreateRoleDto dto);
        Task<Result?> Delete(long roleId);
        Task<List<RoleDto>?> List();
        Task<Result<PageList<RoleDto>>?> PageList(int pageIndex, int pageSize);
        Task<Result<RoleDto>?> Update(UpdateRoleDto dto);
    }
}
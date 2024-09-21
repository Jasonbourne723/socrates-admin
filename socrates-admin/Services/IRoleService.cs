using Models.Request;
using Models.Response;

namespace Services
{
    public interface IRoleService
    {
        Task<RoleDto?> Create(CreateRoleDto dto);
        Task Delete(long roleId);
        Task<List<RoleDto>> List();
        Task<PageList<RoleDto>> PageList(int pageIndex, int pageSize);
        Task<RoleDto?> Update(UpdateRoleDto dto);
    }
}
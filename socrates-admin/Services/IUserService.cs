using Models.Request;
using Models.Response;

namespace Services
{
    public interface IUserService
    {
        Task<UserDto?> Create(CreateUserDto dto);
        Task Delete(long roleId);
        Task<List<UserDto>?> List();
        Task<PageList<UserDto>?> PageList(int pageIndex, int pageSize);
        Task<UserDto?> Update(UpdateUserDto dto);
    }
}
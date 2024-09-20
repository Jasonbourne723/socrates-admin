using Models.Request;
using Models.Response;

namespace Services
{
    public interface IUserService
    {
        Task<Result<UserDto>?> Create(CreateUserDto dto);
        Task<Result?> Delete(long roleId);
        Task<Result<List<UserDto>>?> List();
        Task<Result<PageList<UserDto>>?> PageList(int pageIndex, int pageSize);
        Task<Result<UserDto>?> Update(UpdateUserDto dto);
    }
}
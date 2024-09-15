using Models.Request;
using Models.Response;

namespace Services
{
    public interface IPostService
    {
        Task<Result<PostDto>?> Create(CreatePostDto dto);
        Task<Result?> Delete(long roleId);
        Task<Result<List<PostDto>>?> List();
        Task<Result<PageList<PostDto>>?> PageList(int pageIndex, int pageSize);
        Task<Result<PostDto>?> Update(UpdatePostDto dto);
    }
}
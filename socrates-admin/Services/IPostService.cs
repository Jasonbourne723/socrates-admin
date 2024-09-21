using Models.Request;
using Models.Response;

namespace Services
{
    public interface IPostService
    {
        Task<PostDto?> Create(CreatePostDto dto);
        Task Delete(long roleId);
        Task<List<PostDto>?> List();
        Task<PageList<PostDto>> PageList(int pageIndex, int pageSize);
        Task<PostDto?> Update(UpdatePostDto dto);
    }
}
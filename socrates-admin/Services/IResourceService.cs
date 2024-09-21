using Models.Request;
using Models.Response;

namespace Services
{
    public interface IResourceService
    {
        Task<ResourceDto?> Create(CreateResourceDto dto);
        Task Delete(long ResourceId);
        Task<ResourceDto> GetOne(long ResourceId);
        Task<List<ResourceDto>?> List();
        Task<PageList<ResourceDto>?> PageList(int pageIndex, int pageSize);
        Task<ResourceDto?> Update(UpdateResourceDto dto);
    }
}
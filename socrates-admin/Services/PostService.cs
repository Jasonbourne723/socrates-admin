using Extensions;
using Models.Request;
using Models.Response;
using System.IO;
using System.Net.Http.Json;

namespace Services
{
    public class PostService : IPostService
    {
        private readonly string _path = "/api/post";
        private readonly ICustomHttpClient _customHttpClient;

        public PostService(ICustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<List<PostDto>?> List()
        {
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<List<PostDto>>(_path);
        }

        public async Task<PageList<PostDto>?> PageList(int pageIndex, int pageSize)
        {
            var path = $"{_path}/pagelist?page_index={pageIndex}&page_size={pageSize}";
            return await _customHttpClient.GetAndHandleBusinessErrorAsync<PageList<PostDto>>(path);
        }

        public async Task<PostDto?> Create(CreatePostDto dto)
        {
            return await _customHttpClient.PostAndHandleBusinessErrorAsync<CreatePostDto, PostDto>(_path, dto);
        }

        public async Task<PostDto> Update(UpdatePostDto dto)
        {
            return await _customHttpClient.PutAndHandleBusinessErrorAsync<UpdatePostDto, PostDto>(_path, dto);
        }

        public async Task Delete(long roleId)
        {
            var path = $"{_path}/{roleId}";
            await _customHttpClient.DeleteAndHandleBusinessErrorAsync(path);
        }
    }

}

using Models.Request;
using Models.Response;
using System.IO;
using System.Net.Http.Json;

namespace Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;
        private readonly string _path = "/api/post";

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<List<PostDto>>?> List()
        {
            return await _httpClient.GetFromJsonAsync<Result<List<PostDto>>>(_path);
        }

        public async Task<Result<PageList<PostDto>>?> PageList(int pageIndex, int pageSize)
        {
            var path = $"{_path}/pagelist?page_index={pageIndex}&page_size={pageSize}";
            return await _httpClient.GetFromJsonAsync<Result<PageList<PostDto>>>(path);
        }

        public async Task<Result<PostDto>?> Create(CreatePostDto dto)
        {
            var resposneMessage = await _httpClient.PostAsJsonAsync(_path, dto);
            return await resposneMessage.Content.ReadFromJsonAsync<Result<PostDto>>();
        }

        public async Task<Result<PostDto>?> Update(UpdatePostDto dto)
        {
            var resposneMessage = await _httpClient.PutAsJsonAsync(_path, dto);
            return await resposneMessage.Content.ReadFromJsonAsync<Result<PostDto>>();
        }

        public async Task<Result?> Delete(long roleId)
        {
            var path = $"{_path}/{roleId}";
            var resposneMessage = await _httpClient.DeleteAsync(path);
            return await resposneMessage.Content.ReadFromJsonAsync<Result>();
        }
    }

}

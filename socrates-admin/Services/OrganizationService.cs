﻿using Models.Request;
using Models.Response;
using System.Net.Http;
using System.Net.Http.Json;
using Result = Models.Response.Result;

namespace Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly HttpClient _httpClient;
        private string _path;

        public OrganizationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _path = $"/api/organization";
        }

        public async Task<Result<List<OrganizationNodeDto>>?> All()
        {
            
            return await _httpClient.GetFromJsonAsync<Result<List<OrganizationNodeDto>>>($"{_path}/all");
        }

        public async Task<Result<OrganizationDto>?> Create(CreateOrganizationDto dto)
        {
            var resposneMessage = await _httpClient.PostAsJsonAsync(_path, dto);
            return await resposneMessage.Content.ReadFromJsonAsync<Result<OrganizationDto>>();
        }

        public async Task<Result<OrganizationDto>?> Update(UpdateOrganizationDto dto)
        {
            var resposneMessage = await _httpClient.PutAsJsonAsync(_path, dto);
            return await resposneMessage.Content.ReadFromJsonAsync<Result<OrganizationDto>>();
        }

        public async Task<Result?> Delete(long id)
        {
            var resposneMessage = await _httpClient.DeleteAsync($"{_path}/{id}");
            return await resposneMessage.Content.ReadFromJsonAsync<Result>();
        }

        public async Task<Result<List<OrganizationDto>>?> List()
        {
            return await _httpClient.GetFromJsonAsync<Result<List<OrganizationDto>>>(_path);
        }
    }

}

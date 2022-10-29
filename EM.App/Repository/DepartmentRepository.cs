using EM.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EM.App.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public DepartmentRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task DeleteDepartment(int id)
        {
            await _client.DeleteAsync($"departments/{id}");
        }

        public async Task<List<DepartmentDto>> GetDepartments()
        {

            var response = await _client.GetAsync("departments");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var departments = JsonSerializer.Deserialize<List<DepartmentDto>>(content, _options);

            return departments;
        }

        public async Task<DepartmentDto> GetDepartment(int id)
        {

            var response = await _client.GetAsync($"departments/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var skill = JsonSerializer.Deserialize<DepartmentDto>(content, _options);

            return skill;
        }

        public async Task<DepartmentDto> UpdateDepartment(int id, DepartmentDto departmentDto)
        {

            var json = JsonSerializer.Serialize(departmentDto);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"departments/{id}", requestContent);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var department = JsonSerializer.Deserialize<DepartmentDto>(content, _options);

            return department;
        }

        public async Task<DepartmentDto> CreateDepartment(DepartmentDto departmentDto)
        {

            var json = JsonSerializer.Serialize(departmentDto);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"departments", requestContent);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var department = JsonSerializer.Deserialize<DepartmentDto>(content, _options);

            return department;
        }
    }
}

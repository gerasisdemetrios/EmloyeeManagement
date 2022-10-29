using EM.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EM.App.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public EmployeeRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task DeleteEmployee(int id)
        {
            await _client.DeleteAsync($"employees/{id}");
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {

            var response = await _client.GetAsync("employees");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var employees = JsonSerializer.Deserialize<List<EmployeeDto>>(content, _options);

            return employees;
        }

        public async Task<EmployeeDto> GetEmployee(int id)
        {

            var response = await _client.GetAsync($"employees/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var employee = JsonSerializer.Deserialize<EmployeeDto>(content, _options);

            return employee;
        }

        public async Task<EmployeeDto> UpdateEmployee(int id, EmployeeDto employeeDto)
        {

            var json = JsonSerializer.Serialize(employeeDto);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"employees/{id}", requestContent);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var employee = JsonSerializer.Deserialize<EmployeeDto>(content, _options);

            return employee;
        }

        public async Task<EmployeeDto> CreateEmployee(EmployeeDto employeeDto)
        {

            var json = JsonSerializer.Serialize(employeeDto);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"employees", requestContent);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var employee = JsonSerializer.Deserialize<EmployeeDto>(content, _options);

            return employee;
        }
    }
}

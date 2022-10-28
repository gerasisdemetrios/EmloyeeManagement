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
    public class SkillRepository : ISkillRepository
    {

        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public SkillRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task DeleteSkill(int id)
        {
            await _client.DeleteAsync($"skills/{id}");
        }

        public async Task<List<SkillDto>> GetSkills()
        {

            var response = await _client.GetAsync("skills");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var skills = JsonSerializer.Deserialize<List<SkillDto>>(content, _options);

            return skills;
        }

        public async Task<SkillDto> GetSkill(int id)
        {

            var response = await _client.GetAsync($"skills/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var skill = JsonSerializer.Deserialize<SkillDto>(content, _options);

            return skill;
        }

        public async Task<SkillDto> UpdateSkill(int id, SkillDto skillDto)
        {

            var json = JsonSerializer.Serialize(skillDto);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"skills/{id}", requestContent);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var skill = JsonSerializer.Deserialize<SkillDto>(content, _options);

            return skill;
        }

        public async Task<SkillDto> CreateSkill(SkillDto skillDto)
        {

            var json = JsonSerializer.Serialize(skillDto);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"skills", requestContent);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var skill = JsonSerializer.Deserialize<SkillDto>(content, _options);

            return skill;
        }
    }
}

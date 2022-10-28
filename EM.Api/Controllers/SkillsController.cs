using AutoMapper;
using EM.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using EM.Shared.DTOs;
using System.Threading.Tasks;
using EM.Api.Models;
using Microsoft.AspNetCore.Http;

namespace EM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillRepository _repository;
        private readonly IMapper _mapper;
 
        public SkillsController(ISkillRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDto>>> Get()
        {

            try
            {
                IEnumerable<Skill> skills = await _repository.GetAllAsync();

                IEnumerable<SkillDto> skillsDto = _mapper.Map<IEnumerable<SkillDto>>(skills);


                return Ok(skillsDto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An internal server error occurred.");
            }

        }

        [HttpGet("{id}",Name = "SkillEndpoint")]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            try
            {
                Skill skill = await _repository.GetByIdAsync(id);

                if (skill == null)
                {
                    return NotFound();
                }

                SkillDto skillDto = _mapper.Map<SkillDto>(skill);

                return Ok(skillDto);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An internal server error occurred.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> Update(int id, SkillDto skillDto)
        {
            try
            {
                if (skillDto is null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                if (id != skillDto.Id)
                {
                    return BadRequest();
                }

                Skill existingSkill= await _repository.GetByIdAsync(id);

                if (existingSkill == null)
                {
                    return NotFound();
                }

                _mapper.Map(skillDto, existingSkill);

                await _repository.UpdateAsync(existingSkill);

                return Ok(skillDto);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An internal server error occurred.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(SkillDto skillDto)
        {
            try
            {
                if (skillDto is null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                Skill skill = _mapper.Map<Skill>(skillDto);

                skill.CreatedAt = DateTime.Now;

                Skill createdSkill = await _repository.SaveAsync(skill);

                SkillDto createdSkillDto = _mapper.Map<SkillDto>(createdSkill);

                return CreatedAtRoute("SkillEndpoint", new { id = createdSkillDto.Id }, createdSkillDto);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An internal server error occurred.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existing = await _repository.GetByIdAsync(id);

                if (existing == null)
                {
                    return NotFound();
                }

                await _repository.RemoveAsync(existing);

                return Ok();

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An internal server error occurred.");
            }
        }
    }
}

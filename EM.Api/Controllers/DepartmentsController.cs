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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkgenerator;

        public DepartmentsController(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> Get()
        {

            try
            {
                IEnumerable<Department> departments = await _repository.GetAllAsync();

                IEnumerable<DepartmentDto> departmentsDto = _mapper.Map<IEnumerable<DepartmentDto>>(departments);


                return Ok(departmentsDto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An internal server error occurred.");
            }

        }

        [HttpGet("{id}",Name = "DepartmentEndpoint")]
        public async Task<ActionResult<DepartmentDto>> Get(int id)
        {
            try
            {
                Department department = await _repository.GetByIdAsync(id);

                if (department == null)
                {
                    return NotFound();
                }

                DepartmentDto departmentDto = _mapper.Map<DepartmentDto>(department);

                return Ok(departmentDto);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An internal server error occurred.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DepartmentDto>> Update(int id, DepartmentDto departmentDto)
        {
            try
            {
                if (departmentDto is null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                if (id != departmentDto.Id)
                {
                    return BadRequest();
                }

                Department existingDepartment= await _repository.GetByIdAsync(id);

                if (existingDepartment == null)
                {
                    return NotFound();
                }

                _mapper.Map(departmentDto, existingDepartment);

                await _repository.UpdateAsync(existingDepartment);

                return Ok(existingDepartment);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An internal server error occurred.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentDto departmentDto)
        {
            try
            {
                if (departmentDto is null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                Department department = _mapper.Map<Department>(departmentDto);

                department.CreatedAt = DateTime.Now;

                Department createdDepartment = await _repository.SaveAsync(department);

                DepartmentDto createdDepartmentDto = _mapper.Map<DepartmentDto>(createdDepartment);

                return CreatedAtRoute("DepartmentEndpoint", new { id = createdDepartmentDto.Id }, createdDepartmentDto);

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

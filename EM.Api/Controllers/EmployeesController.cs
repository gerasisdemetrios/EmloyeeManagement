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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;
 
        public EmployeesController(IEmployeeRepository repository, ISkillRepository skillRepository, IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _repository = repository;
            _departmentRepository = departmentRepository;
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
        {

            try
            {
                IEnumerable<Employee> employees = await _repository.GetAllAsync();

                IEnumerable<EmployeeDto> employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);


                return Ok(employeesDto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An internal server error occurred.");
            }

        }

        [HttpGet("{id}",Name = "EmployeeEndpoint")]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            try
            {
                Employee employee = await _repository.GetByIdAsync(id);

                if (employee == null)
                {
                    return NotFound();
                }

                EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);

                return Ok(employeeDto);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An internal server error occurred.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> Update(int id, EmployeeDto employeeDto)
        {
  
            if (employeeDto is null)
            {
                return BadRequest("Owner object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            if (id != employeeDto.Id)
            {
                return BadRequest();
            }

            Employee existingEmployee = await _repository.GetByIdAsync(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            Department department = await _departmentRepository.GetByIdAsync(employeeDto.DepartmentId.Value);

            if (department == null)
            {
                return BadRequest("Not existing department");
            }

            _mapper.Map(employeeDto, existingEmployee);

            await _repository.UpdateAsync(existingEmployee);

            return Ok(employeeDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto employeeDto)
        {
            try
            {
                if (employeeDto is null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                Employee employee = _mapper.Map<Employee>(employeeDto);

                Department department = await _departmentRepository.GetByIdAsync(employee.DepartmentId);

                if (department == null)
                {
                    return BadRequest("Not given department");
                }

                employee.EmployeeSkills = new List<EmployeeSkill>();

                foreach (SkillDto skillDto in employeeDto.Skills)
                {
                    var skill = await _skillRepository.GetByIdAsync(skillDto.Id);

                    if (skill != null)
                    {
                        employee.EmployeeSkills.Add(new EmployeeSkill { SkillId = skill.Id, Skill = skill, Employee = employee });
                    }                    
                }

                employee.CreatedAt = DateTime.Now;

                Employee createdEmployee = await _repository.SaveAsync(employee);

                EmployeeDto createdEmployeeDto = _mapper.Map<EmployeeDto>(createdEmployee);

                return CreatedAtRoute("EmployeeEndpoint", new { id = createdEmployeeDto.Id }, createdEmployeeDto);

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

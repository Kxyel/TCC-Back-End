using Atropos.Api.Dtos;
using Atropos.Data.Models;
using Atropos.Data.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Atropos.Api.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employee)
        {
            var data = _mapper.Map<Employee>(employee);
            var result = await _employeeRepository.AddEmployee(data);
            return Ok(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetEmployees()
        {
            IList<Employee> employees = await _employeeRepository.GetEmployees();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(Guid employeeId)
        {
            var result = await _employeeRepository.GetEmployeeById(employeeId);
            return Ok(result);
        }

        [HttpPut]
        [Route("{employeeId}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto employee, Guid employeeId)
        {
            var data = _mapper.Map<Employee>(employee);
            var result = await _employeeRepository.UpdateEmployee(data, employeeId);
            return Ok(result);
        }

        [HttpDelete]
        [Route("employeeId")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            var result = await _employeeRepository.DeleteEmployee(employeeId);
            return Ok(result);
        }
    }
}

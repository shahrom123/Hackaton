using Domain.Dtos.Employee;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class EmployeeController
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("GetEmployee")]
    public async Task<List<GetEmployeeDto>> GetEmployee()
    {
        return await _employeeService.GetEmployee(); 
    }

    [HttpPost("AddEmployee")]
    public async Task<AddEmployeeDto> AddEmployee(AddEmployeeDto model)
    {
        return await _employeeService.AddEmployee(model);
    }

    [HttpPut("UpdateEmployee")]
    public async Task<AddEmployeeDto> UpdateEmployee(AddEmployeeDto model)
    {
        return await _employeeService.UpdateEmployee(model);
    }

    [HttpDelete("DeleteEmployee")]
    public async Task<bool> DeleteEmployee(int id)
    {
        return await _employeeService.DeleteEmployee(id);
    }

    [HttpGet("GetEmployeeById")]
    public async Task<GetEmployeeDto> GetEmployeeById(int id)
    {
        return await _employeeService.GetEmployeeById(id);
    }

}
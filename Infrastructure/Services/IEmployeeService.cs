using Domain.Dtos;
using Domain.Dtos.Employee;

namespace Infrastructure.Services;

public interface IEmployeeService
{
    Task<List<GetEmployeeDto>> GetEmployee();
    Task<AddEmployeeDto> AddEmployee(AddEmployeeDto model);
    Task<AddEmployeeDto> UpdateEmployee(AddEmployeeDto model);
    Task<bool> DeleteEmployee(int id);
    Task<GetEmployeeDto> GetEmployeeById(int id);
}
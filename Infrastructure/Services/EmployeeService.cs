using Domain.Dtos;
using Domain.Dtos.Employee;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeService:IEmployeeService
{
    private readonly DataContext _context;

    public EmployeeService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GetEmployeeDto>> GetEmployee()
    {
      return await _context.Employees.Select(e => new GetEmployeeDto()
        {
            Id = e.Id,
            FullName = e.FullName,
            CompanyId = e.CompanyId,
            CompanyName = e.Company.Name
            
        }).OrderBy(e=>e.Id).ToListAsync();
    }

    public async Task<GetEmployeeDto> GetEmployeeById(int id)
    {
        var find = await _context.Employees.
            Include(e =>e.Company).SingleOrDefaultAsync(x=>x.Id==id);
        if (find != null)
        {
            return  new GetEmployeeDto()
            {
                Id = find.Id,
                FullName = find.FullName,
                CompanyId = find.CompanyId,
                CompanyName = find.Company.Name 
            };
        }
        else
        {
            return new GetEmployeeDto(); 
        }
    }

    public async Task<AddEmployeeDto> AddEmployee(AddEmployeeDto model)
    {
        var employee = new Employee(model.Id, model.FullName, model.CompanyId);
        await _context.Employees.AddAsync(employee);
        await  _context.SaveChangesAsync();
        model.Id = employee.Id;
        return model;
    }

    public async Task<AddEmployeeDto> UpdateEmployee(AddEmployeeDto model)
    {
        var find =await _context.Employees.FindAsync(model.Id);
        find.FullName = model.FullName;
        find.CompanyId = model.CompanyId;
        await _context.SaveChangesAsync();
        return model; 
    }
    

    public async Task<bool> DeleteEmployee(int id)
    {
        var find = await _context.Employees.FindAsync(id);
        _context.Employees.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }
}
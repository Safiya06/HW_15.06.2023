using Domain.Dtos.Employees;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeService
{
    private readonly DataContext _context;

    public EmployeeService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<GetEmployee>> GetEmployees()
    {
        return await  _context.Employees.Select(e => new GetEmployee()
        {
            Id = e.Id,
            Name = e.Name,
            CompanyId = e.CompanyId
                

        }).ToListAsync();
    }
    public async Task<GetEmployee>GetEmployeeById(int Id)
    {
        var find = await _context.Employees.FindAsync(Id);
        return new GetEmployee()
        {
            Id = find.Id,
            Name = find.Name,
            CompanyId = find.CompanyId
        };
    }
    public async Task< AddEmployee> AddEmployee(AddEmployee employee)
    {
        await  _context.Employees.AddAsync(new Employee()
        {
            Id = employee.Id,
            Name = employee.Name,
            CompanyId = employee.CompanyId
        });
        await _context.SaveChangesAsync();
        return employee;
    }
    public async Task<AddEmployee> UpdateEmployee(AddEmployee employee)
    {
        var find =await _context.Employees.FindAsync(employee.Id);
        find.Name = employee.Name;
        find.CompanyId = employee.CompanyId;
        await _context.SaveChangesAsync();
        return employee;

    }
    public async Task<bool> Delete (int Id)
    {
        var find = await _context.Employees.FindAsync(Id);
        if (find!=null)
        {
            _context.Employees.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
using Domain.Dtos.Employees;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class EmployeeController
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("getemployees")]
    public async Task<List<GetEmployee>> GetEmployees()
    {
        return await  _employeeService.GetEmployees();
    }

    [HttpGet("GetEmployeeById")]
    public async Task<GetEmployee> GetEmployeeById(int Id)
    {
        return await _employeeService.GetEmployeeById(Id);
    }

    [HttpPost("AddEmployee")]
    public async Task<AddEmployee> AddEmployee(AddEmployee addemployee)
    {
        return await _employeeService.AddEmployee(addemployee);
    }
    [HttpPut("UpdateEmployee")]
    public async Task<AddEmployee> UpdateEmployee(AddEmployee addemployee)
    {
        return await _employeeService.UpdateEmployee(addemployee);
    }
    
    [HttpDelete("DeleteEmployee")]
    public async Task<bool> DeleteEmployee(int Id)
    {
        return await _employeeService.Delete(Id);
    }   
}
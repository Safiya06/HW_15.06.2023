using Domain.Dtos.EmployeeSkills;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class EmployeeSkillController
{
    private readonly EmployeeSkillService _employeeSkillService;

    public EmployeeSkillController(EmployeeSkillService employeeSkillService)
    {
        _employeeSkillService = employeeSkillService;
    }

    [HttpGet("getemployeeSkills")]
    public async Task<List<GetEmployeeSkill>> GetEmployeeSkills()
    {
        return await  _employeeSkillService.GetEmployeeSkills();
    }

    [HttpGet("GetEmployeeSkillById")]
    public async Task<GetEmployeeSkill> GetEmployeeSkillById(int EmployeeId)
    {
        return await _employeeSkillService.GetEmployeeSkillById(EmployeeId);
    }

    [HttpPost("AddEmployeeSkill")]
    public async Task<AddEmployeeSkill> AddEmployeeSkill(AddEmployeeSkill addemployeeSkill)
    {
        return await _employeeSkillService.AddEmployeeSkill(addemployeeSkill);
    }
    [HttpPut("UpdateEmployeeSkill")]
    public async Task<AddEmployeeSkill> UpdateEmployeeSkill(AddEmployeeSkill addemployeeSkill)
    {
        return await _employeeSkillService.UpdateEmployeeSkill(addemployeeSkill);
    }
    
    [HttpDelete("DeleteEmployeeSkill")]
    public async Task<bool> DeleteEmployeeSkill(int EmployeeId)
    {
        return await _employeeSkillService.Delete(EmployeeId);
    }   
}
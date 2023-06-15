using Domain.Dtos.EmployeeSkills;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeSkillService
{
    private readonly DataContext _context;

    public EmployeeSkillService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<GetEmployeeSkill>> GetEmployeeSkills()
    {
        return await  _context.EmployeeSkills.Select(es => new GetEmployeeSkill()
        {
            SkillId = es.SkillId,
            EmployeeId = es.EmployeeId
                

        }).ToListAsync();
    }
    public async Task<GetEmployeeSkill>GetEmployeeSkillById(int EmployeeId)
    {
        var find = await _context.EmployeeSkills.FindAsync(EmployeeId);
        return new GetEmployeeSkill()
        {
            SkillId = find.SkillId,
            EmployeeId = find.EmployeeId
        };
    }
    public async Task< AddEmployeeSkill> AddEmployeeSkill(AddEmployeeSkill employeeSkill)
    {
        await  _context.EmployeeSkills.AddAsync(new EmployeeSkill()
        {
            SkillId = employeeSkill.SkillId,
            EmployeeId = employeeSkill.EmployeeId
        });
        await _context.SaveChangesAsync();
        return employeeSkill;
    }
    public async Task<AddEmployeeSkill> UpdateEmployeeSkill(AddEmployeeSkill employeeSkill)
    {
        var find =await _context.EmployeeSkills.FindAsync(employeeSkill.EmployeeId);
        find.SkillId = employeeSkill.SkillId;
        await _context.SaveChangesAsync();
        return employeeSkill;

    }
    public async Task<bool> Delete (int EmployeeId)
    {
        var find = await _context.EmployeeSkills.FindAsync(EmployeeId);
        if (find!=null)
        {
            _context.EmployeeSkills.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
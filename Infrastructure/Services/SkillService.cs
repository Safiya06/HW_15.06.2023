using Domain.Dtos.Skills;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class SkillService
{
    private readonly DataContext _context;

    public SkillService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<GetSkill>> GetSkills()
    {
        return await  _context.Skills.Select(s => new GetSkill()
        {
            Id = s.Id,
            SkillName = s.SkillName
                

        }).ToListAsync();
    }
    public async Task<GetSkill>GetSkillById(int Id)
    {
        var find = await _context.Skills.FindAsync(Id);
        return new GetSkill()
        {
            Id = find.Id,
            SkillName = find.SkillName
        };
    }
    public async Task< AddSkill> AddSkill(AddSkill skill)
    {
        await  _context.Skills.AddAsync(new Skill()
        {
            Id = skill.Id,
            SkillName = skill.SkillName
        });
        await _context.SaveChangesAsync();
        return skill;
    }
    public async Task<AddSkill> UpdateSkill(AddSkill skill)
    {
        var find =await _context.Skills.FindAsync(skill.Id);
        find.SkillName = skill.SkillName;
        await _context.SaveChangesAsync();
        return skill;

    }
    public async Task<bool> Delete (int Id)
    {
        var find = await _context.Skills.FindAsync(Id);
        if (find!=null)
        {
            _context.Skills.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
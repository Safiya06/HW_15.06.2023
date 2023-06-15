using Domain.Dtos.Skills;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class SkillController
{
    private readonly SkillService _skillService;

    public SkillController(SkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpGet("getskills")]
    public async Task<List<GetSkill>> GetSkills()
    {
        return await  _skillService.GetSkills();
    }

    [HttpGet("GetSkillById")]
    public async Task<GetSkill> GetSkillById(int Id)
    {
        return await _skillService.GetSkillById(Id);
    }

    [HttpPost("AddSkill")]
    public async Task<AddSkill> AddSkill(AddSkill addskill)
    {
        return await _skillService.AddSkill(addskill);
    }
    [HttpPut("UpdateSkill")]
    public async Task<AddSkill> UpdateSkill(AddSkill addskill)
    {
        return await _skillService.UpdateSkill(addskill);
    }
    
    [HttpDelete("DeleteSkill")]
    public async Task<bool> DeleteSkill(int Id)
    {
        return await _skillService.Delete(Id);
    }   
}
using Domain.Dtos.Company;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CompanyController
{
    private readonly CompanyService _companyService;

    public CompanyController(CompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet("getcompanies")]
    public async Task<List<GetCompany>> GetCompanys()
    {
        return await  _companyService.GetCompanies();
    }

    [HttpGet("GetCompanyById")]
    public async Task<GetCompany> GetCompanyById(int Id)
    {
        return await _companyService.GetCompanyById(Id);
    }

    [HttpPost("AddCompany")]
    public async Task<AddCompany> AddCompany(AddCompany addcompany)
    {
        return await _companyService.AddCompany(addcompany);
    }
    [HttpPut("UpdateCompany")]
    public async Task<AddCompany> UpdateCompany(AddCompany addcompany)
    {
        return await _companyService.UpdateCompany(addcompany);
    }
    
    [HttpDelete("DeleteCompany")]
    public async Task<bool> DeleteCompany(int Id)
    {
        return await _companyService.Delete(Id);
    }   
}
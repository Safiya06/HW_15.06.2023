using Domain.Dtos.Company;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CompanyService
{
    private readonly DataContext _context;

    public CompanyService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<GetCompany>> GetCompanies()
    {
        return await  _context.Companies.Select(c => new GetCompany()
        {
            Id = c.Id,
            Name = c.Name
                

        }).ToListAsync();
    }
    public async Task<GetCompany>GetCompanyById(int Id)
    {
        var find = await _context.Companies.FindAsync(Id);
        return new GetCompany()
        {
            Id = find.Id,
            Name = find.Name
        };
    }
    public async Task< AddCompany> AddCompany(AddCompany company)
    {
        await  _context.Companies.AddAsync(new Company()
        {
            Id = company.Id,
            Name = company.Name
        });
        await _context.SaveChangesAsync();
        return company;
    }
    public async Task<AddCompany> UpdateCompany(AddCompany company)
    {
        var find =await _context.Companies.FindAsync(company.Id);
        find.Name = company.Name;
        await _context.SaveChangesAsync();
        return company;

    }
    public async Task<bool> Delete (int Id)
    {
        var find = await _context.Companies.FindAsync(Id);
        if (find!=null)
        {
            _context.Companies.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
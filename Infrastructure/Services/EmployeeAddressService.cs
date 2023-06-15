using Domain.Dtos.EmployeeAddress;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeAddressService
{
    private readonly DataContext _context;

    public EmployeeAddressService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<GetEmployeeAddress>> GetEmployeeAddresses()
    {
        return await  _context.EmployeeAddresses.Select(ea => new GetEmployeeAddress()
        {
            Address = ea.Address,
            EmployeeId = ea.EmployeeId
                

        }).ToListAsync();
    }
    public async Task<GetEmployeeAddress>GetEmployeeAddressById(int EmployeeId)
    {
        var find = await _context.EmployeeAddresses.FindAsync(EmployeeId);
        return new GetEmployeeAddress()
        {
            Address = find.Address
        };
    }
    public async Task< AddEmployeeAddress> AddEmployeeAddress(AddEmployeeAddress employeeAddress)
    {
        await  _context.EmployeeAddresses.AddAsync(new EmployeeAddress()
        {
            Address = employeeAddress.Address,
            EmployeeId = employeeAddress.EmployeeId
        });
        await _context.SaveChangesAsync();
        return employeeAddress;
    }
    public async Task<AddEmployeeAddress> UpdateEmployeeAddress(AddEmployeeAddress employeeAddress)
    {
        var find =await _context.EmployeeAddresses.FindAsync(employeeAddress.EmployeeId);
        find.Address = employeeAddress.Address;
        await _context.SaveChangesAsync();
        return employeeAddress;

    }
    public async Task<bool> Delete (int EmployeeId)
    {
        var find = await _context.EmployeeAddresses.FindAsync(EmployeeId);
        if (find!=null)
        {
            _context.EmployeeAddresses.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
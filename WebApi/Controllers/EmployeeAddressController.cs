using Domain.Dtos.EmployeeAddress;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class EmployeeAddressController
{
    private readonly EmployeeAddressService _challengeService;

    public EmployeeAddressController(EmployeeAddressService challengeService)
    {
        _challengeService = challengeService;
    }

    [HttpGet("getchallenges")]
    public async Task<List<GetEmployeeAddress>> GetEmployeeAddresss()
    {
        return await  _challengeService.GetEmployeeAddresses();
    }

    [HttpGet("GetEmployeeAddressById")]
    public async Task<GetEmployeeAddress> GetEmployeeAddressById(int EmployeeId)
    {
        return await _challengeService.GetEmployeeAddressById(EmployeeId);
    }

    [HttpPost("AddEmployeeAddress")]
    public async Task<AddEmployeeAddress> AddEmployeeAddress(AddEmployeeAddress addchallenge)
    {
        return await _challengeService.AddEmployeeAddress(addchallenge);
    }
    [HttpPut("UpdateEmployeeAddress")]
    public async Task<AddEmployeeAddress> UpdateEmployeeAddress(AddEmployeeAddress addchallenge)
    {
        return await _challengeService.UpdateEmployeeAddress(addchallenge);
    }
    
    [HttpDelete("DeleteEmployeeAddress")]
    public async Task<bool> DeleteEmployeeAddress(int EmployeeId)
    {
        return await _challengeService.Delete(EmployeeId);
    }   
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Data.Repository.Interfaces;
using Models;
using Models.DTOs.Create;
using Models.DTOs.Response;
using Repository;
using Service;

public class CoffeeCupService : ICoffeeCupService
{
    private readonly ICoffeeCupRepository _coffeeCupRepository;

    public CoffeeCupService(ICoffeeCupRepository coffeeCupRepository)
    {
        _coffeeCupRepository = coffeeCupRepository;
    }

    public async Task<CoffeeCup> GetCoffeeCupByIdAsync(Guid coffeeCupId)
    {
        return await _coffeeCupRepository.GetByIdAsync(coffeeCupId);
    }

    public async Task<IEnumerable<CoffeeCup>> GetAllCoffeeCupsAsync()
    {
        return await _coffeeCupRepository.GetAllAsync();
    }

    public async Task<Guid> AddCoffeeCupAsync(CoffeeCup coffeeCup)
    {
        // Add coffee cup to the database
        await _coffeeCupRepository.AddAsync(coffeeCup);

        // Return the generated ID
        return coffeeCup.ItemId;
    }

    public async Task UpdateCoffeeCupAsync(CoffeeCup coffeeCup)
    {
        // Add any business logic/validation as needed before calling the repository
        await _coffeeCupRepository.UpdateAsync(coffeeCup);
    }

    public async Task<bool> DeleteCoffeeCupAsync(Guid coffeeCupId)
    {
        var coffeeCup = await _coffeeCupRepository.GetByIdAsync(coffeeCupId);

        if (coffeeCup != null)
        {
            // Add any business logic/validation as needed before calling the repository
            await _coffeeCupRepository.DeleteAsync(coffeeCup);
            return true; // Deletion successful
        }

        return false; // CoffeeCup not found
    }
}
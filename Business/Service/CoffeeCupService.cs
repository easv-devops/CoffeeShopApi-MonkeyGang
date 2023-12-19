using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Repository.Interfaces;
using Models;
using Models.DTOs.Create;
using Models.DTOs.Response;
using Repository;
using Service;

public class CoffeeCupService : ICoffeeCupService
{
    private readonly ICoffeeCupRepository _coffeeCupRepository;
    private readonly IMapper _mapper;

    public CoffeeCupService(ICoffeeCupRepository coffeeCupRepository, IMapper mapper)
    {
        _coffeeCupRepository = coffeeCupRepository;
        _mapper = mapper;
    }

    public async Task<CoffeeCupResponseDto> GetCoffeeCupByIdAsync(Guid coffeeCupId)
    {
        var coffeeCup = await _coffeeCupRepository.GetByIdAsync(coffeeCupId);
        return _mapper.Map<CoffeeCupResponseDto>(coffeeCup);
    }

    public async Task<IEnumerable<CoffeeCupResponseDto>> GetAllCoffeeCupsAsync()
    {
        var coffeeCups = await _coffeeCupRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CoffeeCupResponseDto>>(coffeeCups);
    }

    public async Task<Guid> AddCoffeeCupAsync(CreateCoffeeCupDto createDto)
    {
        var coffeeCup = _mapper.Map<CoffeeCup>(createDto);
        await _coffeeCupRepository.AddAsync(coffeeCup);
        return coffeeCup.ItemId;
    }

    public async Task UpdateCoffeeCupAsync(Guid coffeeCupId, CoffeeCupResponseDto updateDto)
    {
        var existingCoffeeCup = await _coffeeCupRepository.GetByIdAsync(coffeeCupId);

        if (existingCoffeeCup == null)
        {
            return;
        }

        _mapper.Map(updateDto, existingCoffeeCup);
        await _coffeeCupRepository.UpdateAsync(existingCoffeeCup);
    }

    public async Task<bool> DeleteCoffeeCupAsync(Guid coffeeCupId)
    {
        var coffeeCup = await _coffeeCupRepository.GetByIdAsync(coffeeCupId);

        if (coffeeCup != null)
        {
            await _coffeeCupRepository.DeleteAsync(coffeeCup);
            return true;
        }

        return false;
    }

    public async Task<List<CakeResponseDto>> GetCakesForCoffeeCupAsync(Guid coffeeCupId)
    {
        var cakesForCoffeeCup = await _coffeeCupRepository.GetCakesForCoffeeCupAsync(coffeeCupId);
        return _mapper.Map<List<CakeResponseDto>>(cakesForCoffeeCup);
    }
}
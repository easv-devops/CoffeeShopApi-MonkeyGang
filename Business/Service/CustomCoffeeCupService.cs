using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Repository.Interfaces;
using Models;
using Models.DTOs;
using Models.DTOs.Create;
using Models.DTOs.Response;
using Service;

public class CustomCoffeeCupService : ICustomCoffeeCupService
{
    private readonly ICustomCoffeeCupRepository _customCoffeeCupRepository;
    private readonly IMapper _mapper;

    public CustomCoffeeCupService(ICustomCoffeeCupRepository customCoffeeCupRepository, IMapper mapper)
    {
        _customCoffeeCupRepository = customCoffeeCupRepository;
        _mapper = mapper;
    }

    public async Task<CustomCoffeeCupResponseDto> GetCustomCoffeeCupByIdAsync(Guid id)
    {
        var customCoffeeCup = await _customCoffeeCupRepository.GetCustomCoffeeCupByIdAsync(id);
        return _mapper.Map<CustomCoffeeCupResponseDto>(customCoffeeCup);
    }

    public async Task<IEnumerable<CustomCoffeeCupResponseDto>> GetAllCustomCoffeeCupsAsync()
    {
        var customCoffeeCups = await _customCoffeeCupRepository.GetAllCustomCoffeeCupsAsync();
        return _mapper.Map<IEnumerable<CustomCoffeeCupResponseDto>>(customCoffeeCups);
    }

    public async Task<Guid> CreateCustomCoffeeCupAsync(CustomCoffeeCupCreateDto createDto)
    {
        var customCoffeeCup = _mapper.Map<CustomCoffeeCup>(createDto);
        await _customCoffeeCupRepository.CreateCustomCoffeeCupAsync(customCoffeeCup);
        return customCoffeeCup.ItemId;
    }

    public async Task<CustomCoffeeCupResponseDto> UpdateCustomCoffeeCupAsync(Guid id, CustomCoffeeCupDto updateDto)
    {
        var existingCustomCoffeeCup = await _customCoffeeCupRepository.GetCustomCoffeeCupByIdAsync(id);

        if (existingCustomCoffeeCup == null)
        {
            return null;
        }

        _mapper.Map(updateDto, existingCustomCoffeeCup);
        await _customCoffeeCupRepository.UpdateCustomCoffeeCupAsync(existingCustomCoffeeCup);

        return _mapper.Map<CustomCoffeeCupResponseDto>(existingCustomCoffeeCup);
    }

    public async Task<bool> DeleteCustomCoffeeCupAsync(Guid id)
    {
        var isDeleted = await _customCoffeeCupRepository.DeleteCustomCoffeeCupAsync(id);
        return isDeleted;
    }
}
using AutoMapper;
using Models;
using Presentation.DTOs;
using Repository;

namespace Service;

public class CoffeeCupService : ICoffeeCupService
{
    private readonly IMapper _mapper;
    private readonly ICoffeeCupRepository _coffeeCupRepository;

    public CoffeeCupService(IMapper mapper, ICoffeeCupRepository coffeeCupRepository)
    {
        _mapper = mapper;
        _coffeeCupRepository = coffeeCupRepository;
    }

    public CoffeeCupDto GetCoffeeCupById(Guid id)
    {
        var coffeeCup = _coffeeCupRepository.GetCoffeeCupById(id);
        return _mapper.Map<CoffeeCupDto>(coffeeCup);
    }

    public List<CoffeeCupDto> GetAllCoffeeCups()
    {
        var coffeeCups = _coffeeCupRepository.GetAllCoffeeCups();
        return _mapper.Map<List<CoffeeCupDto>>(coffeeCups);
    }

    public void AddCoffeeCup(CoffeeCupDto coffeeCupDto)
    {
        var coffeeCup = _mapper.Map<CoffeeCup>(coffeeCupDto);
        _coffeeCupRepository.AddCoffeeCup(coffeeCup);
    }

    public void UpdateCoffeeCup(CoffeeCupDto coffeeCupDto)
    {
        var coffeeCup = _mapper.Map<CoffeeCup>(coffeeCupDto);
        _coffeeCupRepository.UpdateCoffeeCup(coffeeCup);
    }

    public void DeleteCoffeeCup(Guid id)
    {
        _coffeeCupRepository.DeleteCoffeeCup(id);
    }
}
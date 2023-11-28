using AutoMapper;
using Models;
using Models.DTOs;
using Repository;

namespace Service;

public class CoffeeCupService : ICoffeeCupService
{
    private readonly ICoffeeCupRepository _coffeeCupRepository;
    private readonly IMapper _mapper;

    public CoffeeCupService( IMapper mapper, ICoffeeCupRepository coffeeCupRepository)
    {
        _coffeeCupRepository = coffeeCupRepository;
        _mapper = mapper;
    }

    public CoffeeCupDto GetCoffeeCupById(Guid coffeeCupId)
    {
        var coffeeCupEntity = _coffeeCupRepository.GetCoffeeCupById(coffeeCupId);
        return _mapper.Map<CoffeeCupDto>(coffeeCupEntity);
    }

    public List<CoffeeCupDto> GetAllCoffeeCups()
    {
        var coffeeCupEntities = _coffeeCupRepository.GetAllCoffeeCups();
        return _mapper.Map<List<CoffeeCupDto>>(coffeeCupEntities);
    }

    public void AddCoffeeCup(CoffeeCupDto coffeeCupDto)
    {
        var coffeeCupEntity = _mapper.Map<CoffeeCup>(coffeeCupDto);
        _coffeeCupRepository.AddCoffeeCup(coffeeCupEntity);
    }

    public void UpdateCoffeeCup(CoffeeCupDto coffeeCupDto)
    {
        var coffeeCupEntity = _mapper.Map<CoffeeCup>(coffeeCupDto);
        _coffeeCupRepository.UpdateCoffeeCup(coffeeCupEntity);
    }

    public void DeleteCoffeeCup(Guid coffeeCupId)
    {
        _coffeeCupRepository.DeleteCoffeeCup(coffeeCupId);
    }
}
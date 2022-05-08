using Microsoft.AspNetCore.Mvc;
using REST.Models;
using REST.Repositories;

namespace REST.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    [HttpGet]
    public IEnumerable<City>? GetCities()
    {
        return CityRepository.FindAll();
    }
    
    [HttpGet("{id}")]
    public City? GetCity(int id)
    {
        return CityRepository.Find(id);
    }
    
}
using Microsoft.AspNetCore.Mvc;
using REST.Models;

namespace REST.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    [HttpGet]
    public IEnumerable<City>? GetCities()
    {
        return City.FindAll();
    }
    
    [HttpGet("{id}")]
    public City? GetCity(int id)
    {
        return City.Find(id);
    }
    
}
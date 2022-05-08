using MySql.Data.MySqlClient;
using REST.Models;

namespace REST.Repositories;

public static class CityRepository
{
    public static List<City> FindAll()
    {
        var reader = DbHelper.ExecuteCommand("SELECT * FROM City LEFT JOIN Coords ON City.coords_id = Coords.id");
        if (reader == null) return new List<City>();

        var cities = new List<City>();

        while (reader.Read())
        {
            var city = GetCityFromReader(reader);
            if (city != null) cities.Add(city);
        }
        
        return cities;
    }

    public static City? Find(int id)
    {
        var reader = DbHelper.ExecuteCommand($"SELECT * FROM City LEFT JOIN Coords ON City.coords_id = Coords.id WHERE City.id = {id}");
        return reader == null ? null : GetCityFromReader(reader);
    }

    private static City? GetCityFromReader(MySqlDataReader reader)
    {
        if (!reader.Read()) return null;
        
        var courseId = reader.GetInt16("coords_id");
        var city = new City
        {
            Id = reader.GetInt32("id"),
            Name = reader.GetString("name"),
            District = reader.GetString("district"),
            Population = reader.GetInt32("population"),
            Subject = reader.GetString("subject"),
            CoordsId = courseId,
            Coords = new Coords
            {
                Lat = reader.GetString("lat"),
                Lon = reader.GetString("lon"),
                Id = courseId
            }
        };
        return city;
    }
}
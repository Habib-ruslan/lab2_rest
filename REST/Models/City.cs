using MySql.Data.MySqlClient;

namespace REST.Models;

using System.Text.Json.Serialization;

public class City
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("district")]
    public string District { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("population")]
    public int Population { get; set; }
    [JsonPropertyName("subject")]
    public string Subject { get; set; }
    
    [JsonPropertyName("coords")]
    public Coords Coords { get; set; }

    public int CoordsId { get; set; }

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

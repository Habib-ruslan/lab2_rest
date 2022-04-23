using System.Text.Json.Serialization;

namespace REST.Models
{
    [Serializable]
    public class Coords
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("lat")]
        public string Lat { get; set; }
        [JsonPropertyName("lon")]
        public string Lon { get; set; }
    }
}
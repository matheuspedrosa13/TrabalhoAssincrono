using System.Text.Json.Serialization;

namespace TrabalhoDaniel.Repo.Entities;
public class CreditCard
{
    [JsonPropertyName("type")]
    public string ?Type { get; set; }

    [JsonPropertyName("number")]
    public string ?Number { get; set; }

    [JsonPropertyName("name")]
    public string ?Name { get; set; }

    [JsonPropertyName("expiration")]
    public string ?Expiration { get; set; }
}
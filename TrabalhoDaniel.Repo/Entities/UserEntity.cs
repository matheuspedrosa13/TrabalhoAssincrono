using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrabalhoDaniel.Repo.Entities;
public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    [JsonPropertyName("uuid")]
    public string ?Uuid { get; set; }

    [JsonPropertyName("name")]
    public string ?Name { get; set; }

    [JsonPropertyName("cpf")]
    public string ?Cpf { get; set; }

    [JsonPropertyName("cnpj")]
    public string ?Cnpj { get; set; }

    [JsonPropertyName("birth_date")]
    public string ?BirthDate { get; set; }

    [JsonPropertyName("email")]
    public string ?Email { get; set; }

    [JsonPropertyName("username")]
    public string ?Username { get; set; }

    [JsonPropertyName("password")]
    public string ?Password { get; set; }

    [JsonPropertyName("phone_number")]
    public string ?PhoneNumber { get; set; }

    [JsonPropertyName("domain_name")]
    public string ?DomainName { get; set; }

    [JsonPropertyName("company")]
    public string ?Company { get; set; }

    [JsonPropertyName("ipv4")]
    public string ?Ipv4 { get; set; }

    [JsonPropertyName("user_agent")]
    public string ?UserAgent { get; set; }
    public bool ?Logado = false;

    [JsonPropertyName("Relacoes")]
    public List<string> ?Relacoes = new List<string>();

    [JsonPropertyName("credit_card")]
    public CreditCard ?CreditCard { get; set; }
}
using System.Text.Json;
using System.Text.Json.Serialization;

public partial class Query {
    public List<Film> Films() {
        string fileName = "Database/films.json";
        string jsonString = File.ReadAllText(fileName);
        var films = JsonSerializer.Deserialize<List<Film>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters={new JsonStringEnumConverter()} })!;
        return films;
    }

}   
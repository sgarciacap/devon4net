using System.Text.Json;
using System.Text.Json.Serialization;

public class Query {
    
    public List<Book> Books(string nameContains="")  {
        string fileName = "Database/books.json";
        string jsonString = File.ReadAllText(fileName);
        var books = JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters={new JsonStringEnumConverter()} })!;
        return books.Where(b => b.Name.IndexOf(nameContains)>=0).ToList();
    }

    public List<Magazine> Magazines(string nameContains="")  {
        string fileName = "Database/magazine.json";
        string jsonString = File.ReadAllText(fileName);
        var magazines = JsonSerializer.Deserialize<List<Magazine>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters={new JsonStringEnumConverter()} })!;
        return magazines.Where(b => b.Name.IndexOf(nameContains)>=0).ToList();
    } 

    public List<Film> ViewFilms() {
        string fileName = "Database/films.json";
        string jsonString = File.ReadAllText(fileName);
        var films = JsonSerializer.Deserialize<List<Film>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters={new JsonStringEnumConverter()} })!;
        return films;
    }

}   
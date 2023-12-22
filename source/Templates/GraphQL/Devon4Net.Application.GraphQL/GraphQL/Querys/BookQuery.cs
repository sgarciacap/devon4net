using System.Text.Json;
using System.Text.Json.Serialization;

public partial class Query {
    public List<Book> Books(string nameContains="")  {
        string fileName = "Database/books.json";
        string jsonString = File.ReadAllText(fileName);
        var books = JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters={new JsonStringEnumConverter()} })!;
        return books.Where(b => b.Name.IndexOf(nameContains)>=0).ToList();
    }

}
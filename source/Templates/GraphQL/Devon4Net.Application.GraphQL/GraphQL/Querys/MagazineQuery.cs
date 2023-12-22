using System.Text.Json;
using System.Text.Json.Serialization;
public partial class Query {
    public List<Magazine> Magazines(string nameContains="")  {
            string fileName = "Database/magazine.json";
            string jsonString = File.ReadAllText(fileName);
            var magazines = JsonSerializer.Deserialize<List<Magazine>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters={new JsonStringEnumConverter()} })!;
            return magazines.Where(b => b.Name.IndexOf(nameContains)>=0).ToList();
    } 

}
using System.Text.Json;
using System.Text.Json.Serialization;
using HotChocolate.Subscriptions;

public partial class Mutation {
    public Magazine AddMagazine(MagazineInput input, [Service] ITopicEventSender sender) {
        // Read all current books
        string fileName = "Database/magazine.json";
        string jsonString = File.ReadAllText(fileName);
        var magazines= JsonSerializer.Deserialize<List<Magazine>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;
        
        // Create a new book based on the input
        var rand = new Random();

        var magazine = new Magazine();
        magazine.MagId = rand.Next(1000, 10000);
        magazine.Name = input.Name;
        magazine.Genre = input.Genre;
        magazine.IssueNo = input.IssueNo;

        // Add the new book to the books list and save to the file
        magazines.Add(magazine);
        var json = JsonSerializer.Serialize(magazines);
        File.WriteAllText(fileName,json);

        //Send subscription notification about the new book
        sender.SendAsync("MagazineAdded", magazine);

        // Return the newly created book
        return magazine;
    }
}
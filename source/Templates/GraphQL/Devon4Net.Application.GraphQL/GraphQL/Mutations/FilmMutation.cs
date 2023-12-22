using System.Text.Json;
using System.Text.Json.Serialization;
using HotChocolate.Subscriptions;

public partial class Mutation  {
    public Film AddFilm(FilmInput input, [Service] ITopicEventSender sender) {
        //Read all current films
        string fileName = "Database/films.json";
        string jsonString = File.ReadAllText(fileName);
        var films = JsonSerializer.Deserialize<List<Film>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;
    
        // Create a new film based on the input
        var rand = new Random();

        var film = new Film();
        film.FilmId = rand.Next(100,1000);
        film.FilmName = input.FilmName;
        film.Duration = input.Duration;

        // Add the new film to the films list and save to the file
        films.Add(film);
        var json = JsonSerializer.Serialize(films);
        File.WriteAllText(fileName, json);

        //Send subscription notification about a new film
        sender.SendAsync("FilmAdded", film);

        //Return the created film
        return film;
    }

    

    

    
}
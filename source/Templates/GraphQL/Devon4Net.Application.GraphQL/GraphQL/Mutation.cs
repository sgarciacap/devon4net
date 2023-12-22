using System.Text.Json;
using System.Text.Json.Serialization;
using HotChocolate.Subscriptions;

public class Mutation  {

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

    public Book AddBook(BookInput input, [Service] ITopicEventSender sender)  {

        // Read all current books
        string fileName = "Database/books.json";
        string jsonString = File.ReadAllText(fileName);
        var books= JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;
        
        // Create a new book based on the input
        var rand = new Random();

        var book = new Book();
        book.BookId = rand.Next(1000, 10000);
        book.Name = input.Name;
        book.Genre = input.Genre;
        book.Pages = input.Pages;
        book.Price = input.Price;
        book.PublishDate = input.PublishDate;

        // Add the new book to the books list and save to the file
        books.Add(book);
        var json = JsonSerializer.Serialize(books);
        File.WriteAllText(fileName,json);

        //Send subscription notification about the new book
        sender.SendAsync("BookAdded", book);

        // Return the newly created book
        return book;
    }

    
}
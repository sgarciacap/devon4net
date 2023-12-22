public class Subscription {
    
    [Subscribe]
    public Book BookAdded([EventMessage]Book newBook) => newBook;

    [Subscribe]
    public Film FilmAdded([EventMessage]Film newFilm) => newFilm;

    [Subscribe]
    public Magazine MagazineAdded([EventMessage]Magazine newMagazine) => newMagazine;
}
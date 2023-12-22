public partial class Subsciption {

    [Subscribe]
    public Film FilmAdded([EventMessage]Film newFilm) => newFilm;

}
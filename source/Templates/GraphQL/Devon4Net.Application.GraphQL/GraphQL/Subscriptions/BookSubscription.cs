public partial class Subsciption {
    
    [Subscribe]
    public Book BookAdded([EventMessage]Book newBook) => newBook;

}
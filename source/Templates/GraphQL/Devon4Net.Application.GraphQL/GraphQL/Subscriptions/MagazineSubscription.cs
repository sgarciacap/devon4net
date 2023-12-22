public partial class Subscription {

    [Subscribe]
    public Magazine MagazineAdded([EventMessage]Magazine newMagazine) => newMagazine;

}
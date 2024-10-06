public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public PetType Type { get; set; }
    public Breed Breed { get; set; }
    public string DateOfBirth { get; set; }
}

public enum Breed
{
    Mix,
    Beagle,
    Boxer,
    Bulldog,
    Chihuahua,
    Dachshund,
    GermanShepherd,
    GoldenRetriever,
    LabradorRetriever,
    Poodle,
    Rottweiler,
    SiberianHusky,
    YorkshireTerrier,
    Abyssinian,
    Bengal,
    Birman,
    Bombay,
    BorderCollie,
}

public enum PetType
{
    Dog,
    Cat,
    Fish,
    Bird,
    Reptile,
    Rodent,
    Other
}
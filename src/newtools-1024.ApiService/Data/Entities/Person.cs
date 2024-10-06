using System.Runtime.InteropServices.JavaScript;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public List<Pet> Pets { get; set; } = new List<Pet>();
}
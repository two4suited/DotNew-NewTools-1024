using System.ComponentModel.DataAnnotations;

namespace newtools1024.ApiService.Data.Entities
{

    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public List<Pet> Pets { get; set; } = [];
    }
}
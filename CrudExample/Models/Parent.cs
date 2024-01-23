using System.Text.Json.Serialization;

namespace CrudExample.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}

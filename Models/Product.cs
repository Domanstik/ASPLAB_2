using System.ComponentModel.DataAnnotations;

namespace ASPLAB_2.Models
{
    public class Product
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int? Prise { get; set; }
    }
}

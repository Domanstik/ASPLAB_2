using System.ComponentModel.DataAnnotations;

namespace ASPLAB_2.Models
{
    public class Stationery
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}

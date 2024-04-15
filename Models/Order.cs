using System.ComponentModel.DataAnnotations;

namespace ASPLAB_2.Models
{
    public class Order
    {
        [Key] public int Id { get; set; }
        public string User { get; set; } = string.Empty;
        public int? ProductsCost { get; set; }
    }
}

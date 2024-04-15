using System.ComponentModel.DataAnnotations;

namespace ASPLAB_2.Models
{
    public class Order
    {
        [Key] public int Id { get; set; }
        private string User { get; set; } = string.Empty;
        private int? ProductsCost { get; set; }
    }
}

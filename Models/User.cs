using System.ComponentModel.DataAnnotations;

namespace ASPLAB_2.Models
{
    public class User
    {
        [Key] public int Id { get; set; }
        private string Name { get; set; } = string.Empty;
        private string Email { get; set; } = string.Empty;
    }
}

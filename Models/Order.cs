namespace ASPLAB_2.Models
{
    public class Order
    {
        private int Id { get; set; }
        private string User { get; set; } = string.Empty;
        private List<string> Products { get; set; }
    }
}

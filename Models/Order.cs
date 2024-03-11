namespace ASPLAB_2.Models
{
    public class Order
    {
        private int Id { get; set; }
        private User User { get; set; }
        private List<Product> Products { get; set; }
    }
}

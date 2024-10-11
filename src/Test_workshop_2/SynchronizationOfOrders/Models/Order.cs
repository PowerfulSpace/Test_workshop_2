namespace SynchronizationOfOrders.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; } = null!;
        public string Product { get; set; } = null!;
    }
}

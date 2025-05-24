namespace IdentityText.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ClassGroupId { get; set; }
        public ClassGroup ClassGroup { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }

}

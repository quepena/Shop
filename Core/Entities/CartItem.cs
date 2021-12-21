namespace Core.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
    }
}
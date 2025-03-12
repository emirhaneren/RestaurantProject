namespace EntityLayer.Entities
{
    public class Basket
    {
        public int BasketID { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int MenuTableID { get; set; }
        public MenuTable MenuTable { get; set; }
    }
}

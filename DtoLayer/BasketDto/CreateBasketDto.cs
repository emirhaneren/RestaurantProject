namespace DtoLayer.BasketDto
{
    public class CreateBasketDto
    {
        public decimal ProductPrice { get; set; }
        public decimal ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
    }
}

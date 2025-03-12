namespace WebUI.Dtos.BasketDtos
{
    public class ResultBasketDto
    {
        public int BasketID { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
        public string ProductName {  get; set; }
    }
}

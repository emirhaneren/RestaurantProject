﻿namespace DtoLayer.DiscountDto
{
    public class CreateDiscountDto
    {
        public string DiscountTitle { get; set; }
        public string DiscountDescription { get; set; }
        public bool Status { get; set; }
        public string Amount { get; set; }
        public string ImageUrl { get; set; }
    }
}

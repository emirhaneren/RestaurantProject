using EntityLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        int TProductCount();
        int TProductCountByCategoryNameHamburger();
        int TProductCountByCategoryNameDrink();
        decimal TProductPriceAvg();
        string TProductNameByMinPrice();
        string TProductNameByMaxPrice();
        decimal TProductPriceByHamburger();
    }
}

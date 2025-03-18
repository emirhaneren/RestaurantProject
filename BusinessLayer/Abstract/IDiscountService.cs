using EntityLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
        void TChangeStatus(int id);
        List<Discount> TGetActiveDiscounts();
    }
}

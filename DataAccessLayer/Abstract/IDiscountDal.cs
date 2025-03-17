using EntityLayer.Entities;

namespace DataAccessLayer.Abstract
{
    public interface IDiscountDal : IGenericDal<Discount>
    {
        void ChangeStatus(int id);
    }
}

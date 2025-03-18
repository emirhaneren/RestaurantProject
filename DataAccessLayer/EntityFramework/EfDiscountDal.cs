using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(Context context) : base(context)
        {
        }

        public void ChangeStatus(int id)
        {
            var context = new Context();
            var discount = context.Discounts.Find(id);
            if(discount.Status)
            {
                discount.Status = false;
            }
            else
            {
                discount.Status = true;
            }
            context.Update(discount);
            context.SaveChanges();
        }

        public List<Discount> GetActiveDiscounts()
        {
            var context = new Context();
            return context.Discounts.Where(x => x.Status == true).ToList();
        }
    }
}

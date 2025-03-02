using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(Context context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            using var context = new Context();
            return context.Categories.Where(x => x.CategoryStatus == true).Count();
        }

        public int CategoryCount()
        {
            using var context = new Context();
            return context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            using var context = new Context();
            return context.Categories.Where(x => x.CategoryStatus == false).Count();
        }
    }
}

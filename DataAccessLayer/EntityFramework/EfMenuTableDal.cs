using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        public EfMenuTableDal(Context context) : base(context)
        {
        }

        public int MenuTableCount()
        {
            using var context = new Context();
            return context.MenuTables.Count();
        }
    }
}

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

        public void ChangeMenuTableStatusToFalse(int id)
        {
            var context = new Context();
            var value = context.MenuTables.Where(x => x.MenuTableID == id).FirstOrDefault();
            value.Status = false;
            context.SaveChanges();
        }

        public void ChangeMenuTableStatusToTrue(int id)
        {
            var context = new Context();
            var value = context.MenuTables.Where(x => x.MenuTableID == id).FirstOrDefault();
            value.Status = true;
            context.SaveChanges();
        }

        public int MenuTableCount()
        {
            using var context = new Context();
            return context.MenuTables.Count();
        }
    }
}

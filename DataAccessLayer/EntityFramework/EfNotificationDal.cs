using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(Context context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationByStatusFalse()
        {
            var context = new Context();
            return context.Notifications.Where(x => x.Status == false).ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            var context = new Context();
            return context.Notifications.Where(x => x.Status == false).Count();
        }

        public void UpdateStatus(int id)
        {
            var context = new Context();
            var notification = context.Notifications.Find(id);
            if(notification.Status == false)
            {
                notification.Status = true;
                context.SaveChanges();
            }
            else
            {
                notification.Status = false;
                context.SaveChanges();
            }
        }
    }
}

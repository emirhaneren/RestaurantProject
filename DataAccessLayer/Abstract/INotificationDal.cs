using EntityLayer.Entities;

namespace DataAccessLayer.Abstract
{
    public interface INotificationDal:IGenericDal<Notification>
    {
        int NotificationCountByStatusFalse();
        List<Notification> GetAllNotificationByStatusFalse();
        void UpdateStatus(int id);
    }
}

using EntityLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        public int TNotificationCountByStatusFalse();
        public List<Notification> TGetAllNotificationByStatusFalse();
        void TUpdateStatus(int id);
    }
}

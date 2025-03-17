using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void BookingStatusApproved(int id)
        {
            var context = new Context();
            var booking = context.Bookings.Find(id);
            booking.Description = "Onaylandı";
            context.Update(booking);
            context.SaveChanges();
        }

        public void BookingStatusCancelled(int id)
        {
            var context = new Context();
            var booking = context.Bookings.Find(id);
            booking.Description = "İptal Edildi";
            context.Update(booking);
            context.SaveChanges();
        }
    }
}

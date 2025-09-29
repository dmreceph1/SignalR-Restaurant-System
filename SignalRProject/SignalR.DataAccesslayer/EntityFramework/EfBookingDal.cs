using SignalR.DataAccesslayer.Abstract;
using SignalR.DataAccesslayer.Concrete;
using SignalR.DataAccesslayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccesslayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

        public void bookingStatusDescriptionApprove(int id)
        {
            using var context = new SignalRContext();
            var booking = context.Bookings.Find(id);
            booking.Description = "Rezavasyon Onaylandı";
            context.SaveChanges();
        }

        public void bookingStatusDescriptionCancel(int id)
        {
            using var context = new SignalRContext();
            var booking = context.Bookings.Find(id);
            booking.Description = "Rezavasyon İptal Edildi";
            context.SaveChanges();
        }
    }
}

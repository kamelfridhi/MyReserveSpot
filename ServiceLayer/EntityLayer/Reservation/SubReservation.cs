using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Reservation
{
    public class SubReservation
    {
        public  Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}

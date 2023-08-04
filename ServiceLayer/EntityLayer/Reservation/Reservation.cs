using EntityLayer.MemberShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Reservation
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime FirstReservationDate { get; set; }
        public DateTime LastReservationDate { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid StatuId { get; set; }
        public Statu Statu { get; set; }
        public virtual ICollection<SubReservation> SubReservation { get; set; }
    }
}

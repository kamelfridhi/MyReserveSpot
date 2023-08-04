using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Reservation
{
    public  class TransitionHistoric
    {
        public Guid Id { get; set; }
        public Guid TransionId { get; set; }
        public Transition Transition { get; set; }
        public DateTime TransitionDate { get; set; }
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Reservation
{
    public class DtoSubReservation
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ReservationId { get; set; }
    }
}

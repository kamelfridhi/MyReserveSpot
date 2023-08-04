using System;

namespace RespositoryPatternWithUOW.Api.Model.Reservation
{
    public class SubReservationModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ReservationId { get; set; }
    }
}

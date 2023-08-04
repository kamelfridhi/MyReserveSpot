namespace ClientWeb.Models.Reservation
{
    public class ReservationModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime FirstReservationDate { get; set; }
        public DateTime LastReservationDate { get; set; }
        public string email { get; set; }
    }
    
}

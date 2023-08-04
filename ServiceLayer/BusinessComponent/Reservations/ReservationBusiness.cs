using DtoLayer.Reservation;
using EntityLayer.Reservation;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Enum;

namespace BusinessComponent.Reservations
{
    public class ReservationBusiness
    {
        private readonly IUnitOfWork Data;
        public ReservationBusiness(IUnitOfWork UnitOfWork)
        {
            Data = UnitOfWork;
        }

        
        public void AddReservation(DtoReservation dtoReservation)
        {
            var changeStatu = new ChangeStatutes();
            //DtoToEntity
            var reservation=new Reservation();
            reservation.Id= Guid.NewGuid();
            reservation.StatuId = GetStatuId(EnumStatus.Initial.ToString());
            reservation.UserId = GetUserId(dtoReservation.email);
            reservation.Description = dtoReservation.Description;
            reservation.Title = dtoReservation.Title;
            reservation.LastReservationDate = dtoReservation.LastReservationDate;
            reservation.FirstReservationDate = dtoReservation.FirstReservationDate;
            Func<string,Guid> getStatuId = GetStatuId;
            changeStatu.ApplyChange(getStatuId,EnumStatus.Initial,ref reservation,null,dtoReservation.UserPermission);
            Data.Reservations.Add(reservation);
            Data.Complete();
        }
        public Guid GetStatuId(string statu)
        {
            var statuId=Data.StatuRepositorys.Find(s=>s.Name==statu).Id;
            return statuId;
        }
        public Guid GetUserId(string email)
        {
            var userId =Data.Users.Find(u=>u.Email==email).Id;
            return userId;
        }
        



    }
}

using DtoLayer.Reservation;
using EntityLayer.Reservation;
using RepositoryPatternWithUOW.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponent.Reservations
{
    public class SubReservationBusiness
    {
        private readonly IUnitOfWork Data;
        public SubReservationBusiness(IUnitOfWork UnitOfWork)
        {
            Data = UnitOfWork;
        }
        public void AddSubReservation(DtoSubReservation dtoSubReservation)
        {

            //DtoToEntity
            var subReservation = new SubReservation();
            subReservation.Id = Guid.NewGuid();
            subReservation.Description = dtoSubReservation.Description;
            subReservation.Title = dtoSubReservation.Title;
            subReservation.ReservationId = dtoSubReservation.ReservationId;
            Data.SubReservations.Add(subReservation);
            Data.Complete();
        }
       
        
       

    }
}

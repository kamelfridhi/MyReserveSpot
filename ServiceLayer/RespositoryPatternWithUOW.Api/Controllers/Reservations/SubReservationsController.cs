using BusinessComponent.Reservations;
using DtoLayer.Reservation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RespositoryPatternWithUOW.Api.Model.Reservation;
using System;

namespace RespositoryPatternWithUOW.Api.Controllers.Reservations
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubReservationsController : ControllerBase
    {
        private readonly IUnitOfWork Data;
        private static Lazy<SubReservationBusiness> SubReservationrBusinessValue;
        public SubReservationsController(IUnitOfWork unitOfWork)
        {
            Data = unitOfWork;
            SubReservationrBusinessValue = new Lazy<SubReservationBusiness>(() => new SubReservationBusiness(Data)); ;
        }

        [HttpPost("AddSubReservation")]
        public IActionResult AddReservation(SubReservationModel subReservationModel)
        {
            var subReservationDto = new DtoSubReservation();
            //ModelToDto
            subReservationDto.ReservationId = subReservationModel.ReservationId;
            subReservationDto.Description = subReservationModel.Description;
            subReservationDto.Title = subReservationModel.Title;
            
            

            SubReservationrBusinessValue.Value.AddSubReservation(subReservationDto);
            return Ok();
        }
    }
}

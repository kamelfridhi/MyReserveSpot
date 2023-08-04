using BusinessComponent.Reservations;
using BusinessComponent.UserBusiness;
using DtoLayer.Reservation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RespositoryPatternWithUOW.Api.Model;
using RespositoryPatternWithUOW.Api.Model.Reservation;
using System;
using System.Collections.Generic;

namespace RespositoryPatternWithUOW.Api.Controllers.Reservations
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IUnitOfWork Data;
        private static Lazy<ReservationBusiness> ReservationrBusinessValue;
        public ReservationsController(IUnitOfWork unitOfWork)
        {
            Data = unitOfWork;
            ReservationrBusinessValue = new Lazy<ReservationBusiness>(() => new ReservationBusiness(Data)); ;
        }

        [HttpPost("AddReservation")]
        public IActionResult AddReservation(ReservationModel reservationModel)
        {
            var reservationDto = new DtoReservation();
            //ModelToDto
            reservationDto.email= reservationModel.email;
            reservationDto.Description = reservationModel.Description;
            reservationDto.Title = reservationModel.Title;
            reservationDto.LastReservationDate = reservationModel.LastReservationDate;
            reservationDto.FirstReservationDate = reservationModel.FirstReservationDate;

            ReservationrBusinessValue.Value.AddReservation(reservationDto);
            return Ok();
        }

        [HttpGet("GetAllReservations")]
        public List<ReservationModel> GetAllReservations()
        {
            var Reservations = Data.Reservations.GetAll();
            var listOfReservationModel = new List<ReservationModel>();

            //mappig entity to model
            foreach (var Reservation in Reservations)
            {
                var ReservationModel = new ReservationModel();
                ReservationModel.Title = Reservation.Title;
                ReservationModel.Description = Reservation.Description;
                ReservationModel.FirstReservationDate = Reservation.FirstReservationDate;
                ReservationModel.LastReservationDate = Reservation.LastReservationDate;
                listOfReservationModel.Add(ReservationModel);
            }

            return listOfReservationModel;
        }
    } 
}

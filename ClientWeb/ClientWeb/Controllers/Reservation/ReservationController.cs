using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using RestSharp;
using System.Net;
using ClientWeb.Models.Reservation;
using System.Linq;


namespace ClientWeb.Controllers.Reservation
{
    public class ReservationController : Controller
    {
        // Action pour afficher le formulaire de création de réservation
        [HttpGet]
        public ActionResult Reservation()
        {

           
            return View("Reservation");
        }


        [HttpPost]
        public ActionResult Reservation(ReservationModel reservation)
        {
            var serializedMicrosoftEventObject = Newtonsoft.Json.JsonConvert.SerializeObject(reservation);
            var restClient = new RestClient("https://localhost:5001/api");
            var restRequest = new RestRequest("/Reservation/AddReservation", Method.Post);
            restRequest.AddParameter("application/json", serializedMicrosoftEventObject, ParameterType.RequestBody);
            var response = restClient.Execute(restRequest);

            var AddReservation = Newtonsoft.Json.JsonConvert.DeserializeObject<ReservationModel>(response.Content);
            return View("Confirmation");
        }

        [HttpGet]
        public ActionResult AfficheReservations()
        {            
            var restClient = new RestClient("https://localhost:5001/api");
            var restRequest = new RestRequest("/Reservations/GetAllReservations", Method.Get);
            restRequest.AddParameter("application/json", ParameterType.RequestBody);
            var response = restClient.Execute(restRequest);
            var GetAllReservations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReservationModel>>(response.Content);
            return View("AllReservations");
        }


    }
}

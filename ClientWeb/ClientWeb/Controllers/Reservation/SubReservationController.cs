using ClientWeb.Models.Reservation;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace ClientWeb.Controllers.Reservation
{
    public class SubReservationController : Controller
    {
        [HttpGet]
        public ActionResult SubReservation()
        {


            return View("~/Views/Reservation/SubReservation.cshtml");
        }


        [HttpPost]
        public ActionResult SubReservation(SubReservationModel subReservation)
        {
            var serializedMicrosoftEventObject = Newtonsoft.Json.JsonConvert.SerializeObject(subReservation);
            var restClient = new RestClient("https://localhost:5001/api");
            var restRequest = new RestRequest("/Reservation/AddSubReservation", Method.Post);
            restRequest.AddParameter("application/json", serializedMicrosoftEventObject, ParameterType.RequestBody);
            var response = restClient.Execute(restRequest);

            var AddSubReservation = Newtonsoft.Json.JsonConvert.DeserializeObject<SubReservationModel>(response.Content);
            return View("~/Views/Reservation/Confirmation.cshtml");
        }
    }
}

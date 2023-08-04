using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;
//using System.Web.Secutity;
using ClientWeb.Models.MemberShip;

using System.Linq;

namespace ClientWeb.Controllers
{
    public class AccountsController : Controller
    {
        // GET: LoginController
        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {

            var serializedMicrosoftEventObject = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            var restClient = new RestClient("https://localhost:5001/api");
            var restRequest = new RestRequest("/User/CheckUserAccount", Method.Post);
            restRequest.AddParameter("application/json", serializedMicrosoftEventObject, ParameterType.RequestBody);
            var response = restClient.Execute(restRequest);

            var checkUserAccount = Newtonsoft.Json.JsonConvert.DeserializeObject<SendBooleanValue>(response.Content);
            if (user.Email == "admin@gmail.com" && user.Password == "admin123")
            {

                // Session["IsLoggedIn"] = true;



                return RedirectToAction("Dashboard", "Admin");
                //return RedirectToAction("Dashboard", "Admin");
            }
            else 
            {

                return View("~/Views/Reservation/ReservationHome.cshtml");
            }


            return View("Login", user);
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View("Login");
        }



        public ActionResult SignIn(SignInViewModel user)
        {
            if (ModelState.IsValid) // Check if the model is valid (data from the form is correctly filled)
            {
                var t = CheckIfUserAlreadyExist(user);
                if (t)
                {
                    //return View(user);
                    return View("Success");
                }


                return View(user);

            }

            // If the ModelState is not valid (e.g., required fields are missing), return the same view with validation errors.
            return View(user);

        }

        private bool CheckIfUserAlreadyExist(SignInViewModel user)
        {

            var serializedMicrosoftEventObject = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            var restClient = new RestClient("https://localhost:5001/api");
            var restRequest = new RestRequest("/User/AddUser", Method.Post);
            restRequest.AddParameter("application/json", serializedMicrosoftEventObject, ParameterType.RequestBody);
            var response = restClient.Execute(restRequest);
            var isUserAlreadyExist = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);


            if (response.IsSuccessful && response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }


    }
}

using ClientWeb.Models.MemberShip;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RestSharp;
using System.Net;

namespace ClientWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
                      
            var user = new UserModel();
            user.Email = "kamel.alsaidi@ensi-uma.tn";
            user.Name = "kamel.alsaidi";
            user.Password ="123@";
            //var serializedMicrosoftEventObject = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            //var restClient = new RestClient("https://localhost:5001/api");
            //var restRequest = new RestRequest("/User/AddOne", Method.Post);           
            //restRequest.AddParameter("application/json", serializedMicrosoftEventObject, ParameterType.RequestBody);

            //var t=CheckIfUserAlreadyExist(user);
            //if (t)
            //{
            //    return View(user);
                
            //}
            //var response = restClient.Execute(restRequest);

            return View();
        }
        private bool CheckIfUserAlreadyExist(UserModel user)
        {

            var serializedMicrosoftEventObject = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            var restClient = new RestClient("https://localhost:5001/api");
            var restRequest = new RestRequest("/User/CheckUser", Method.Post);
            restRequest.AddParameter("application/json", serializedMicrosoftEventObject, ParameterType.RequestBody);
            var response = restClient.Execute(restRequest);
            var isUserAlreadyExist = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);


            if (response.IsSuccessful && response.StatusCode== HttpStatusCode.OK) 
            {
                return true;
            }
            return false;
        }
        public IActionResult Privacy()
        {
            

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
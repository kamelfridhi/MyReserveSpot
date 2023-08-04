using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ClientWeb.Models.MemberShip;

using System.Linq;
using RestSharp;
using System.Net;

namespace ClientWeb.Controllers.MemberShip
{
    public class AdminController : Controller
    {
        
        public ActionResult Dashboard(AdminDashboardViewModel user )
        {

            var serializedMicrosoftEventObject = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            var restClient = new RestClient("https://localhost:5001/api");
            var restRequest = new RestRequest("/User/GetAllUsers", Method.Get);
            restRequest.AddParameter("application/json", serializedMicrosoftEventObject, ParameterType.RequestBody);
            var response = restClient.Execute(restRequest);
            var GetAllUsers = Newtonsoft.Json.JsonConvert.DeserializeObject <List<UserModel>> (response.Content);


            
            return View(GetAllUsers);
        }

       
            public ActionResult Details(AdminDashboardViewModel user)
            {
                var serializedMicrosoftEventObject = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                var restClient = new RestClient("https://localhost:5001/api");
                var restRequest = new RestRequest("/User/GetUserById", Method.Get);
                restRequest.AddParameter("application/json", serializedMicrosoftEventObject, ParameterType.RequestBody);
                var response = restClient.Execute(restRequest);
                
            var GetUserById = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(response.Content);

            
                return View(GetUserById); 
            }


        public class delet
        {
            public string email { get; set; }
        }
        public ActionResult Delete(string email)
        {
            var d=new delet();
            d.email = email;

            var serializedMicrosoftEventObject = Newtonsoft.Json.JsonConvert.SerializeObject(d);
            var restClient = new RestClient("https://localhost:5001/api");
            var restRequest = new RestRequest("/User/DeleteUser", Method.Post);
            restRequest.AddParameter("application/json", serializedMicrosoftEventObject, ParameterType.RequestBody);
            var response = restClient.Execute(restRequest);
            var DeleteUser = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(response.Content);


            return View();
        }



    }

}

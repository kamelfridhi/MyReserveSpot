using BusinessComponent.UserBusiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Consts;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.EF;
using System;
using System.Collections.Generic;
using RespositoryPatternWithUOW.Api.Model;
using DtoLayer;
using AutoMapper;
using EntityLayer.MemberShip;
using EntityLayer.Reservation;
using System.Linq;
using System.Collections.Immutable;
using System.Globalization;
using DtoLayer.MemberShip;
using System.Net.Http.Json;

namespace RespositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
             
        private readonly IUnitOfWork Data;
        private static Lazy<UserBusiness> UserBusinessValue;
        public UserController(IUnitOfWork unitOfWork)
        {
            Data = unitOfWork;
            UserBusinessValue = new Lazy<UserBusiness>(() => new UserBusiness(Data)); ;
        }
        
        
        [HttpGet("GetById")]
        public IActionResult GetById()
        {
            return Ok();
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(UserModel userModel)
            {           
            
            var customerDto = new UserDto();
            //ModelToDto
            customerDto.Name = userModel.Name;
            customerDto.Email = userModel.Email;
            customerDto.Password = userModel.Password;
            UserBusinessValue.Value.AddUser(customerDto);                     
            return Ok();
        }
        [HttpPost("CheckUser")]
        public bool CheckUser(UserModel userModel)
        {           
            var customerDto = new UserDto();
            customerDto.Name = userModel.Name;
            customerDto.Email = userModel.Email;
            customerDto.Password = userModel.Password;

            //modelToDto:Dto Data transfert Object
            //dtoToModel
            //var isUserAlreadyExist=UserBusinessValue.Value.CheckeUser(customerDto);
            
            return true;
        }

        [HttpPost("CheckUserAccount")]
        public SendBooleanValue CheckUserAccount(UserAccount userAccount)
        {
            var val = new SendBooleanValue();
            var checkEmailAndPassword = Data.Users.Find(e=>e.Email==userAccount.Email&& e.Password == userAccount.Password);           
            if (checkEmailAndPassword.Email!=null&& checkEmailAndPassword.Password != null)
                val.value = true;                          
            return val;
        }

        [HttpGet("GetAllUsers")]
        public List<UserModel> GetAllUsers()
        {
            var users=Data.Users.GetAll();
            var listOfuserModel = new List<UserModel>();
           
            //mappig entity to model
            foreach (var user in users)
            {
                var userModel = new UserModel();
                userModel.Email= user.Email;
                userModel.Name = user.Name;
                listOfuserModel.Add(userModel);
            }

            return listOfuserModel;
        }

        [HttpGet("GetUserById")]
        public User GetUserById(string email)
        {
            var user = Data.Users.Find(e=>e.Email== email);
            //EntityToModel
            var userModel = new UserModel();
            
            user.Name = userModel.Name;                     
            return user;
        }

        [HttpPost("DeleteUser")]
        public IActionResult DeleteUser(Delet email)
        {
            var user = Data.Users.Find(e => e.Email == email.email);

            if (user != null || user.Name != "admin")
            {
                Data.Users.Delete(user);
                Data.Complete();

                
            }
            else
            {
                 return NotFound("User not found.");
            }
            return Ok("User deleted successfully.");
        }

        public class Delet
        {
            public string email { get; set; }
        }
    }
}

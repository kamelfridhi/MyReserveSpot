using AutoMapper;
using DtoLayer;
using EntityLayer.MemberShip;
using System;

namespace RespositoryPatternWithUOW.Api.Model
{
    public class UserModel
    {       
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

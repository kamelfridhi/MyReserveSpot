using DtoLayer;
using DtoLayer.MemberShip;
using EntityLayer.MemberShip;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.EF;
using RepositoryPatternWithUOW.EF.MemberShip.MemberShipAndUnitOfwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponent.UserBusiness
{
    public  class UserBusiness 
    {
        private readonly IUnitOfWork Data;
        public UserBusiness(IUnitOfWork UnitOfWork)
        {
            Data=UnitOfWork;
        }
       
        public void AddUser(UserDto userDto)
        {
            var user = new User();
            user.Id = Guid.NewGuid();
            user.Password = userDto.Password;
            user.Email = userDto.Email;
            user.Name = userDto.Name;
            Data.Users.Add(user);
            AddUserRole(user);
            Data.Complete();
        }
        private void AddUserRole(User user)
        {
            var id = from role in Data.Roles.GetAll() where role.Name == "user" select role.Id;
            var userRole = new UserRole();
            userRole.Id = Guid.NewGuid();
            userRole.UserId = user.Id;
            userRole.RoleId = id.First();
            Data.UserRoles.Add(userRole);
        }
        
       


    }

}

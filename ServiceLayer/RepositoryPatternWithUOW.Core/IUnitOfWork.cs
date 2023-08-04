using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using RepositoryPatternWithUOW.EF.MemberShip.Interfase;

namespace RepositoryPatternWithUOW.Core
{
    public interface IUnitOfWork : IDisposable
    {     
        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public IReservationReposirtory Reservations { get; }
        public IUserRoleRepository UserRoles { get;}
        public ISubReservationRepository SubReservations { get; }
        public IStatuRepository StatuRepositorys { get; }    
        public ITransitions Transitions { get; }
        public int Complete();
    }
}
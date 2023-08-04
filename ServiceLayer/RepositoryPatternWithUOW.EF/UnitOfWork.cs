using EntityLayer.MemberShip;
using EntityLayer.Reservation;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.EF.MemberShip;
using RepositoryPatternWithUOW.EF.Repositories;
using RepositoryPatternWithUOW.EF.Reservations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        

        public IUserRepository Users  { get; private set; }

        public IReservationReposirtory Reservations { get; private set; }

        public IRoleRepository Roles { get; private set; }
        public IUserRoleRepository UserRoles { get; private set; }
        public ISubReservationRepository SubReservations { get; private set; }
        public IStatuRepository StatuRepositorys { get; private set; }
        public ITransitions Transitions { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users=new UserRepository(_context);
            Roles = new RoleRepository(_context);
            UserRoles = new UserRoleRepository(_context);
            Reservations = new ReservationReposirtory(_context);
            SubReservations = new SubReservationRepository(_context);
            StatuRepositorys=new StatuRepository(_context);
            Transitions = new TransitionRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        

        private bool _disposedValue=false;

        ~UnitOfWork()
        {
            Dispose(false);
        }  

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }

           
        }
    }
}
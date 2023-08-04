using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Reservation;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.EF.Repositories;

namespace RepositoryPatternWithUOW.EF.Reservations
{
    public class ReservationReposirtory : BaseRepository<Reservation>, IReservationReposirtory
    {
        private readonly ApplicationDbContext _context;
        public ReservationReposirtory(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}

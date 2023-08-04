using EntityLayer.Reservation;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Reservations
{
    public class TransitionRepository: BaseRepository<Transition>, ITransitions
    {
        private readonly ApplicationDbContext _context;
        public TransitionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

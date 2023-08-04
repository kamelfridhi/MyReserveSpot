using EntityLayer.Reservation;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.EF.Repositories;

namespace RepositoryPatternWithUOW.EF.Reservations
{
    public class StatuRepository:BaseRepository<Statu>, IStatuRepository
    {
        private readonly ApplicationDbContext _context;
        public StatuRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

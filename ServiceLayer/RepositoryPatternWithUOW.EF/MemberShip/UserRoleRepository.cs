using EntityLayer.MemberShip;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.MemberShip
{
    public  class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

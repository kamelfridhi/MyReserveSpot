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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {       
        public UserRepository(ApplicationDbContext context) : base(context)
        {                    
        }
    }
}

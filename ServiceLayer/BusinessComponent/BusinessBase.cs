using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.EF;
using RepositoryPatternWithUOW.EF.MemberShip.MemberShipAndUnitOfwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponent
{
    public  class BusinessBase<Entity> where Entity : IMemberShipAndUnitOfwork, new()
    {
        protected BusinessBase()
        {            
            Data = new Entity();
        }
        
        public Entity Data 
        { get; private set; 
        }
    }
}

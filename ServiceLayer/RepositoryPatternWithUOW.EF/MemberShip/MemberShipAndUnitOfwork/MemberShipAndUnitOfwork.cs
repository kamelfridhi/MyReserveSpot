using EntityLayer.MemberShip;
using RepositoryPatternWithUOW.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.MemberShip.MemberShipAndUnitOfwork
{

    public  interface IMemberShipAndUnitOfwork:IDisposable
    {       
        public int commit();

    }

    public abstract class UnitOfWorkBase: IMemberShipAndUnitOfwork
    {
        
        public int commit()
        {
            return this.commit();
        }
        public void Dispose() 
        {
            this.Dispose();
        }

        protected abstract ApplicationDbContext InitiContext(ApplicationDbContext context); 
    }
    public class MemberShipAndUnitOfwork: UnitOfWorkBase
    {
        
        public UserRepository Users { get;private set; }
        public MemberShipAndUnitOfwork() 
        {
            //Users = new UserRepository(this);          
        }

        protected override ApplicationDbContext InitiContext(ApplicationDbContext context)
        {
            return context;
        }
    }
}

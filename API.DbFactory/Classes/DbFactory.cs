using API.Db.Model;
using API.DbFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DbFactory.Classes
{
    public class DbFactory : IDbFactory
    {
        private LicentaEntities dbContext;

        public LicentaEntities Init()
        {
            return this.dbContext ?? (dbContext = new LicentaEntities());
        }
    }
}

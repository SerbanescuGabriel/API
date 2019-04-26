using API.Db.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DbFactory.Interfaces
{
    public interface IDbFactory
    {
        LicentaEntities Init();
    }
}

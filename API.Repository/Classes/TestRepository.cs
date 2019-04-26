using API.Db.Model;
using API.Repository.BusinessEntities;
using API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Classes
{
    class TestRepository : ITestRepository
    {
        private LicentaEntities dbContext;

        public TestRepository(LicentaEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<UnitEntity> GetAllUnits()
        {
            return dbContext.Units.Select(unit => new UnitEntity() { UnitId = unit.UnitId, UnitName = unit.UnitName }).ToList();
        }
    }
}

﻿using API.Repository.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Interfaces
{
    public interface ITestRepository
    {
        List<UnitEntity> GetAllUnits();
    }
}

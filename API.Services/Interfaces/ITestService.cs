﻿using API.Repository.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface ITestService
    {
        List<UnitEntity> GetAllUnits();
    }
}

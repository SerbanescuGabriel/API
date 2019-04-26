using API.Repository.BusinessEntities;
using API.Repository.Interfaces;
using API.Services.Interfaces;
using System.Collections.Generic;

namespace API.Services.Classes
{
    public class TestService : ITestService
    {
        ITestRepository testRepository;

        public TestService(ITestRepository testRepository)
        {
            this.testRepository = testRepository;
        }

        public List<UnitEntity> GetAllUnits()
        {
            return testRepository.GetAllUnits();
        }
    }
}

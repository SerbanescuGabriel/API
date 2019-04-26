using API.Repository.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Interfaces
{
    public interface IUserRepository
    {
        long AddUser(UserEntity userEntity);

        UserEntity Login(string username, string password);

        bool UserNameAlreadyExists(string username);
    }
}

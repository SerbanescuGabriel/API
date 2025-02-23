﻿using API.Repository.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IUserService
    {
        UserEntity AddUser(UserEntity userEntity);

        UserEntity Login(string username, string password);

        bool UserNameAlreadyExists(string username);

        UserEntity GetUserById(long userId);
    }
}

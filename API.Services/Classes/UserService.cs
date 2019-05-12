using API.Repository.BusinessEntities;
using API.Repository.Interfaces;
using API.Services.Interfaces;
using API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Classes
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserEntity AddUser(UserEntity userEntity)
        {
            userEntity.Password = EncryptionHelper.EncryptSHA256(userEntity.Password);
            return this.userRepository.AddUser(userEntity);
        }

        public UserEntity GetUserById(long userId)
        {
            return this.userRepository.GetById(userId);
        }

        public UserEntity Login(string username, string password)
        {
            return this.userRepository.Login(username, EncryptionHelper.EncryptSHA256(password));
        }

        public bool UserNameAlreadyExists(string username)
        {
            return this.userRepository.UserNameAlreadyExists(username);
        }
    }
}

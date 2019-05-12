using API.Db.Model;
using API.Repository.BusinessEntities;
using API.Repository.Interfaces;
using API.Repository.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Classes
{
    public class UserRepository : GenericRepository, IUserRepository
    {
        private LicentaEntities dbContext;

        public UserRepository(LicentaEntities dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public UserEntity AddUser(UserEntity userEntity)
        {
            UserDetail userDetail = new UserDetail()
            {
                FirstName = "",
                LastName = "",
                Age = 0,
                Sex = true,
                ProfilePicture = ""
            };
            dbContext.UserDetails.Add(userDetail);
            dbContext.SaveChanges();

            var user = new User()
            {
                Username = userEntity.Username,
                Password = userEntity.Password,
                Email = userEntity.Email,
                UserDetailId = userDetail.UserDetailId
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return user != null ? UserMapper.UserEntityMapper(user) : null;
        }

        public UserEntity GetById(long userId)
        {
            var user = this.dbContext.Users
                .Include("UserDetail")
                .Where(u => u.UserId == userId)
                .FirstOrDefault();

            return user != null ? UserMapper.UserEntityMapper(user) : null;
        }

        public UserEntity Login(string username, string password)
        {
            var user = this.dbContext.Users
                .Include("UserDetail")
                .Where(u => u.Username == username && u.Password == password)
                .FirstOrDefault();

            return user != null ? UserMapper.UserEntityMapper(user) : null;
        }

        public bool UserNameAlreadyExists(string username)
        {
            return this.DbContext.Users.FirstOrDefault(u => u.Username.Equals(username)) != null ? true : false;
        }
    }
}

using API.Db.Model;
using API.Repository.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Mappers
{
    public class UserMapper
    {
        public static UserDetailEntity UserDetailMapper(UserDetail userDetail)
        {
            return new UserDetailEntity()
            {
                UserDetailId = userDetail.UserDetailId,
                FirstName = userDetail.FirstName,
                LastName = userDetail.LastName,
                Age = (int)userDetail.Age,
                Sex = (bool)userDetail.Sex,
                ProfilePicture = userDetail.ProfilePicture
            };
        }

        public static UserEntity UserEntityMapper(User user)
        {
            return new UserEntity()
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                UserDetails = UserDetailMapper(user.UserDetail)
            };
        }
    }
}

using API.Entities.Requests;
using API.Entities.ResponseCodes;
using API.Repository.BusinessEntities;
using API.Services.Interfaces;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IHttpActionResult AddUser(RegisterUserRequest request)
        {
            if (request == null)
            {
                return this.Ok(ErrorCodes.ErrorInvalidParameters);
            }
            else if (this.userService.UserNameAlreadyExists(request.Username))
            {
                return this.Ok(ErrorCodes.ErrorUsernameIsTaken);
            }

            var userEntity = new UserEntity() { Username = request.Username, Password = request.Password, Email = request.Password };

            var UserId = this.userService.AddUser(userEntity);

            if (UserId > 0)
            {
                return this.Ok(new { SuccessCodes.SucessUserAdded, UserId });
            }
            else
            {
                return this.Ok(ErrorCodes.ErrorUserNotAdded);
            }
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginRequest request)
        {
            if (request == null)
            {
                return this.Ok(ErrorCodes.ErrorInvalidParameters);
            }

            var user = this.userService.Login(request.Username, request.Password);

            if (user != null)
            {
                return this.Ok(new { SuccessCodes.SucessLogin, user });
            }
            else
            {
                return this.Ok(ErrorCodes.ErrorInvalidCredentials);
            }
        }
    }
}

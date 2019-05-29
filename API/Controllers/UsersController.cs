using API.Entities.Requests;
using API.Entities.ResponseCodes;
using API.Repository.BusinessEntities;
using API.Services.Interfaces;
using API.Services.ServiceEnums;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserService userService;
        private readonly IEmailService emailService;

        public UsersController(IUserService userService, IEmailService emailService)
        {
            this.userService = userService;
            this.emailService = emailService;
        }

        [HttpPost]
        public IHttpActionResult AddUser(RegisterRequest request)
        {
            if (request == null)
            {
                return this.Ok(ErrorCodes.ErrorInvalidParameters);
            }
            else if (this.userService.UserNameAlreadyExists(request.Username))
            {
                return this.Ok(ErrorCodes.ErrorUsernameIsTaken);
            }

            var userEntity = new UserEntity() {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email };

            var userDetail = new UserDetailEntity()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                Sex = request.Sex
            };

            userEntity.UserDetails = userDetail;

            var user = this.userService.AddUser(userEntity);

            if (user.UserId > 0)
            {
                var emailResult = this.emailService.SendEmail(EmailTypeEnum.AccountCreationConfirmationEmail, request.Email);
                if (emailResult.Equals("OK"))
                {
                    return this.Ok(user);
                }
                else
                {
                    return null;
                }
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
                return this.Ok(user);
            }
            else
            {
                return this.Ok(ErrorCodes.ErrorInvalidCredentials);
            }
        }

        [HttpGet]
        [Route("{userId}")]
        public IHttpActionResult GetUserById([FromUri]long userId)
        {
            if (userId > 0)
                return this.Ok(userService.GetUserById(userId));
            else
                return this.BadRequest(ErrorCodes.ErrorInvalidParameters);
        }
    }
}

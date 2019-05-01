using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entities.ResponseCodes
{
    public class ErrorCodes
    {
        #region General
        public static readonly string ErrorInvalidParameters = "Error_InvalidParameters";
        #endregion

        #region User Error Codes
        public static readonly string ErrorUserNotAdded = "Error_UserNotAdded";
        public static readonly string ErrorInvalidCredentials = "Error_InvalidCredentials";
        public static readonly string ErrorUsernameIsTaken = "Error_UsernameIsTaken";
        #endregion
    }
}
using API.Services.ServiceEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IEmailService
    {
        string SendEmail(EmailTypeEnum emailType, string emailAddress);
    }
}

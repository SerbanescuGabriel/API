using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Utils
{
    public class EncryptionHelper
    {
        public static string EncryptSHA256(string stringToEncrypt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(stringToEncrypt);
            byte[] inArray = HashAlgorithm.Create("SHA256").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
    }
}

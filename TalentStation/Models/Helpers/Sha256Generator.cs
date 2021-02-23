using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TalentStation.Models.Helpers
{
    public class Sha256Generator
    {
        public static string ComputeString(string text)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = mySHA256.ComputeHash(sourceBytes);
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
        }
    }
}

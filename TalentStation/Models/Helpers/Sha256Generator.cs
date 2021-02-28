using System;
using System.Security.Cryptography;
using System.Text;

namespace TalentStation.Models.Helpers
{
    public class Sha256Generator
    {
        public static string ComputeString(string text)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] sourceBytes = Encoding.UTF8.GetBytes(text);
            byte[] hashBytes = sha256.ComputeHash(sourceBytes);
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        }
    }
}

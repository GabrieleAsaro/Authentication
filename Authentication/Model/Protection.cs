using System;
using System.Security.Cryptography;
using System.Text;

namespace Authentication.Model
{
    public class Protection
    {
        public static string Sha256(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            using (var sha = new SHA256Managed())
            {
                var textData = Encoding.UTF8.GetBytes(value);
                var hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }
    }
}

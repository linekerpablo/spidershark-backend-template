using System;
using System.Security.Cryptography;
using System.Text;

namespace SpiderShark.Domain.UseCases
{
    public class HashPasswordUseCase
    {
        public static string Execute(string password)
        {
            byte[] val = Encoding.UTF8.GetBytes(password);

            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(val);

                return Convert.ToBase64String(hash);
            }
        }
    }
}

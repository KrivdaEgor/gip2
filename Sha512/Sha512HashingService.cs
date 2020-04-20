using Abstractions;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Sha512
{
    public class Sha512HashingService : IHashingService
    {
        public string CaclulateHash(string source)
        {
            using (var algorithm = SHA512.Create())
            {
                byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(source));
                return new string(hash.SelectMany(a => a.ToString("X2")).ToArray());
            }
        }
    }
}

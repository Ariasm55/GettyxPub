
using System.Security.Cryptography;


namespace Getty.Core.Helpers
{
    public partial class PasswordHasher
    {
        public static void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedhash.SequenceEqual(passwordHash);
            }
        }
    }
}

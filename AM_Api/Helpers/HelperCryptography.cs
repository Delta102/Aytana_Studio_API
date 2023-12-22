using System.Security.Cryptography;
using System.Text;

namespace AM_Api.Helpers
{
    public class HelperCryptography
    {
        public static string GenerateSalt()
        {
            string salt = "";
            for (int i = 1; i <= 50; i++)
            {
                int randomNumber = RandomNumberGenerator.GetInt32(0, 255);
                char letter = Convert.ToChar(randomNumber);
                salt += letter;
            }
            return salt;
        }

        public static bool compareArrays(byte[] a, byte[] b)
        {
            bool iguales = true;
            if (a.Length != b.Length)
            {
                iguales = false;
            }
            else
            {
                //comparamos byte a byte
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i].Equals(b[i]) == false)
                    {
                        iguales = false;
                        break;
                    }
                }
            }

            return iguales;
        }

        public static byte[] EncryptPassword(string password, string salt)
        {
            string content = password + salt;
            byte[] contentBytes = Encoding.UTF8.GetBytes(content);

            using ( SHA256 sHA256 = SHA256.Create())
            {
                byte[] hash = contentBytes;

                for (int i = 1; i <= 107; i++)
                {
                    hash = sHA256.ComputeHash(hash);
                }
                return hash;
            }
        }
    }
}
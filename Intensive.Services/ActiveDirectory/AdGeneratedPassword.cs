using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.ActiveDirectory
{
    public class AdGeneratedPassword
    {
        //        public DateTime? Expires { get; internal set; }

            //expiration, i.e., the "account-expiration" attributes is stored in a FILETIME structure/format

        public DateTime Expires { get; internal set; }
        public string Password { get; internal set; }

        public AdGeneratedPassword()
        {
            this.Password = string.Empty;
            this.Expires = DateTime.MaxValue;
        }

        //public AdGeneratedPassword(int pwdAgeInHours)
        //{
        //    this.Password = GeneratePassword();
        //    this.Expires = DateTime.UtcNow.AddHours(pwdAgeInHours);
        //}

        /// <summary>
        /// Generate a random 20-character password.
        /// </summary>
        /// <remarks>
        /// <para>This method uses a cryptographically secure random number generator to generate a random 20-character
        /// password meeting the characteristics described by the <see cref="IsAcceptable"/> method. The password is
        /// equivalent in strength to a 119.08-bit random sequence (14.89 bytes).</para>
        /// </remarks>
        /// <returns>
        /// The generated password.
        /// </returns>
        public void GeneratePassword(int pwdLength)
        {
            GeneratePassword(pwdLength,0);
        }


        public void GeneratePassword(int pwdLength, int pwdAgeInHours)
        {
            RandomNumberGenerator RandomNumberGenerator = new RNGCryptoServiceProvider();

            string password;
            do
            {
                byte[] data = new byte[pwdLength];
                RandomNumberGenerator.GetBytes(data);
                password = Convert.ToBase64String(data);
            } while (!IsAcceptable(password));

            RandomNumberGenerator.Dispose();

            this.Expires = DateTime.UtcNow.AddHours(pwdAgeInHours);
            this.Password = password;
        }


        /// <summary>
        /// This method determines if a password is "acceptable". Acceptable passwords contain at least one upper-case
        /// letter, one lower-case letter, and one digit. In addition, acceptable passwords only contain letters and
        /// digits.
        /// </summary>
        /// <remarks>
        /// <para>By restricting acceptable passwords to only containing letters and digits, it ensures users can
        /// double-click the password and always have the complete password selected. When symbols are used,
        /// double-clicking may result in parts of the password being treated as distinct words, thus requiring more
        /// work for the users to use the password.</para>
        /// </remarks>
        /// <param name="password">The candidate password.</param>
        /// <returns>
        /// <para><see langword="true"/> if the password is acceptable.</para>
        /// <para>-or-</para>
        /// <para><see langword="false"/> if the password is not acceptable.</para>
        /// </returns>
        private static bool IsAcceptable(string password)
        {
            
            if (!password.Any(char.IsUpper)) return false;      // require an upper-case letter
            
            if (!password.Any(char.IsLower)) return false;      // require a lower-case letter
            
            if (!password.Any(char.IsDigit)) return false;      // require a digit
            
            if (!password.All(char.IsLetterOrDigit)) return false;  // avoid symbols

            return true;
        }
    }
}

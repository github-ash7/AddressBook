using System.Text;

namespace Services.Helpers
{
    public static class CommonMethods
    {
        private static string key = "qwertyLKJ@Zm[7]";

        //Encrypted password is stored in the DB

        /// <summary>
        /// Encrypts the Password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>

        public static string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) 
                return "";
            password += key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);   
        }

        //Decrypted password is sent as a response to the user

        /// <summary>
        /// Decrypts the password 
        /// </summary>
        /// <param name="base64EncodeData"></param>
        /// <returns></returns>

        public static string DecryptPassword(string base64EncodeData)
        {
            if (string.IsNullOrEmpty(base64EncodeData)) 
                return "";
            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - key.Length);
            return result;
        }
    }
}

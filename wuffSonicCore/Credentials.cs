using System;
using System.Security.Cryptography;
using System.Text;
namespace wuffSonic
{
    public class Credentials
    {
        private string _password;
        public string uri { get; set; }
        public string version { get; set; }
        public string appName { get; set; }
        public string user { get; set; }
        public string password
        {
            // Only used if version < 1.13.0
            get
            {
                return BitConverter.ToString(Encoding.UTF8.GetBytes(_password)).Replace("-", "");
            }
            set
            {
                _password = value;
            }
        }

        public string salt { get; private set; }
        public string token
        {
            get
            {
                // Starting from v1.13.0 we send an authenticated token= md5(password+salt)
                return GetMd5Hash(_password + salt);
            }
        }


        public Credentials(string uri, string version, string appName, string user, string password)
        {
            this.uri = uri;
            this.version = version;
            this.appName = appName;
            this.user = user;
            this.password = password;
        }

        // For each request we must create a new salt.
        public void RegenerateSalt()
        {
            salt = GetRandomSalt(20);
        }

        // source - https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?view=netframework-4.7.2
        private string GetMd5Hash(string input)
        {
            byte[] data = null;
            // Convert the input string to a byte array and compute the hash.
            using (MD5 md5Hash = MD5.Create())
            {
                data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // source - https://stackoverflow.com/a/1344255
        private string GetRandomSalt(int size)
        {
            char[] chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
    }
}
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using TaskoMask.Services.Monolith.Domain.Core.Services;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Services.Security
{
    public class EncryptionService : IEncryptionService
    {
        #region Ctors

        public EncryptionService()
        {

        }


        #endregion

        #region Public Methods

        /// <summary>
        /// Create a password hash by SHA256
        /// </summary>
        public string CreateSaltKey(int size)
        {
            var rng = RandomNumberGenerator.Create();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }



        /// <summary>
        /// 
        /// </summary>
        public string CreatePasswordHash(string password, string saltkey)
        {
            var saltAndPassword = string.Concat(password, saltkey);
            HashAlgorithm algorithm = SHA256.Create();

            var hashByteArray = algorithm.ComputeHash(Encoding.UTF8.GetBytes(saltAndPassword));
            return BitConverter.ToString(hashByteArray).Replace("-", "");
        }



        /// <summary>
        /// Decrypt text
        /// </summary>
        public string EncryptText(string plainText, string privateKey)
        {
            if (string.IsNullOrEmpty(plainText))
                return plainText;

            if (string.IsNullOrEmpty(privateKey) || privateKey.Length != 24)
                throw new Exception("Wrong private key");

            var tDES = TripleDES.Create();

            tDES.Key = new ASCIIEncoding().GetBytes(privateKey.Substring(0, 24));
            tDES.IV = new ASCIIEncoding().GetBytes(privateKey.Substring(16, 8));

            byte[] encryptedBinary = EncryptTextToMemory(plainText, tDES.Key, tDES.IV);
            return Convert.ToBase64String(encryptedBinary);
        }



        /// <summary>
        /// 
        /// </summary>
        public string DecryptText(string cipherText, string encryptionPrivateKey)
        {
            if (string.IsNullOrEmpty(cipherText))
                return cipherText;

            if (string.IsNullOrEmpty(encryptionPrivateKey) || encryptionPrivateKey.Length != 24)
                throw new Exception("Wrong encryp private key");

            var tDES = TripleDES.Create();
            tDES.Key = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(0, 24));
            tDES.IV = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(16, 8));

            byte[] buffer = Convert.FromBase64String(cipherText);
            return DecryptTextFromMemory(buffer, tDES.Key, tDES.IV);
        }

        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private byte[] EncryptTextToMemory(string data, byte[] key, byte[] iv)
        {
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, TripleDES.Create().CreateEncryptor(key, iv), CryptoStreamMode.Write))
                {
                    byte[] toEncrypt = new UnicodeEncoding().GetBytes(data);
                    cs.Write(toEncrypt, 0, toEncrypt.Length);
                    cs.FlushFinalBlock();
                }

                return ms.ToArray();
            }
        }



        /// <summary>
        /// 
        /// </summary>
        private string DecryptTextFromMemory(byte[] data, byte[] key, byte[] iv)
        {
            using (var ms = new MemoryStream(data))
            {
                using (var cs = new CryptoStream(ms, TripleDES.Create().CreateDecryptor(key, iv), CryptoStreamMode.Read))
                {
                    var sr = new StreamReader(cs, new UnicodeEncoding());
                    return sr.ReadLine();
                }
            }
        }


        #endregion
    }
}

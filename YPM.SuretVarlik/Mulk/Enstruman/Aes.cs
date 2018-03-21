using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace YPM.SuretVarlik.Mulk.Enstruman
{
    /// <summary>
    /// Türetilemeyen bu sınıf genellikle şifreleme işlemlerini üstlenir.
    /// </summary>
    public sealed class Aes
    {
        private static byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");

        /// <summary>
        /// Verilen string ifadeyi AES kullanarak şifreler.
        /// </summary>
        /// <para>
        /// plainText şu an gireceğiniz işaret yeni string cümledir.
        /// sharedSecret şu an gireceğiniz işarete karşılık şifreleme için kullanılacak paroladır.
        /// </para>
        /// <param name="plainText">şifrelenecek metin</param>
        /// <returns>Şifrelenmiş metin</returns>
        public static string Sifrele(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");
            if (string.IsNullOrEmpty("!#qweASDzxc369-*852147"))
                throw new ArgumentNullException("sharedSecret");

            string outStr = null;
            RijndaelManaged aesAlg = null;
            MemoryStream msEncrypt = null;

            try
            {
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes("!#qweASDzxc369-*852147", _salt);
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                msEncrypt = new MemoryStream();
                msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);

                using (StreamWriter swEncrypt = new StreamWriter(new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)))
                {
                    swEncrypt.Write(plainText);
                }

                outStr = Convert.ToBase64String(msEncrypt.ToArray());
            }
            finally
            {
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return outStr;
        }

        /// <summary>
        /// Şifrelenen metnin şifresini çözer.
        /// </summary>
        /// <para>
        /// plainText şu an gireceğiniz işaret yeni string cümledir.
        /// sharedSecret şu an gireceğiniz işarete karşılık şifreleme için kullanılacak paroladır.
        /// </para>
        /// <param name="cipherText">Çözülecek metin</param>
        /// <returns>Çözülmüş metin</returns>
        public static string Coz(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");
            if (string.IsNullOrEmpty("!#qweASDzxc369-*852147"))
                throw new ArgumentNullException("sharedSecret");

            RijndaelManaged aesAlg = null;

            string plaintext = null;

            MemoryStream msDecrypt = null;

            CryptoStream csDecrypt = null;

            try
            {
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes("!#qweASDzxc369-*852147", _salt);

                byte[] bytes = Convert.FromBase64String(cipherText);
                msDecrypt = new MemoryStream(bytes);

                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                aesAlg.IV = ReadByteArray(msDecrypt);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                    plaintext = srDecrypt.ReadToEnd();
            }
            finally
            {
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }

        private static byte[] ReadByteArray(Stream s)
        {
            byte[] rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }

            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }

            return buffer;
        }
    }
}
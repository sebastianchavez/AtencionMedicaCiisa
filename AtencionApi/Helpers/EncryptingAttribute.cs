using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AtencionApi.Helpers
{
    public class EncryptingAttribute
    {
        // Encriptacion en MD5
        public string EncryptMD5(string pwd)
        {
            byte[] hash;
            StringBuilder sb = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                hash = md5.ComputeHash(Encoding.UTF8.GetBytes(pwd));
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }

            }
            return sb.ToString();
        }
    }
}

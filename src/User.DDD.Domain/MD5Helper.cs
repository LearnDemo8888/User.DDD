using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace User.DDD.Domain
{
    public class MD5Helper
    {
        /// <summary>
        /// 16位MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt16(string password)
        {
            using var md5 = MD5.Create();


            var data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            // 循环遍历哈希数据的每一个字节并格式化为十六进制字符串 
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("X2"));
            }
            string result4 = builder.ToString().Substring(8, 16);
            return result4;
        }
    }
}

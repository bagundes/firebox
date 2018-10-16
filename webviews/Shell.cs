using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace webviews
{
    public class Shell
    {
        private static readonly string key = "qrdWmmEHIibiy146FbpPk98tbrvRetU";
        public static readonly string passwdRegex = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$";
        
        public static bool IsValidPasswd(string passwd)
        {
            if(string.IsNullOrEmpty(passwd))
                throw new System.Exception("Senha não pode ser vazia.");

            var ER = new Regex(Shell.passwdRegex, RegexOptions.None);

            return ER.IsMatch(passwd);
        }

        public static string HashMD5(string val, string key = null)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(val));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            if(string.IsNullOrEmpty(key))
                return sBuilder.ToString();
            else
                return HashMD5($"{Shell.key}{val}{key}{sBuilder.ToString()}");

        }
    }
}
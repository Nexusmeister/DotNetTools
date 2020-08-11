using Newtonsoft.Json;
using Tools.Core.Tools.Security;

namespace Tools.Core.DTOs.Administration
{
    /// <summary>
    /// DTO für EMail-Logininformationen
    /// </summary>
    public class EMailCredentialsDto
    {
        private string _passwordDecrypted;

        [JsonProperty("mailUser")]
        public string Username { get; set; }

        [JsonProperty("mailPasswordDecrypted")]
        public string PasswordDecrypted {
            get
            {
                if (string.IsNullOrWhiteSpace(_passwordDecrypted))
                {
                    _passwordDecrypted =  Encrypter.Decrypt(PasswordEncrypted, PassPhrase);
                }

                return _passwordDecrypted;
            }
        }

        [JsonProperty("mailPasswordEncrypted")]
        public string PasswordEncrypted { get; set; }

        [JsonProperty("encryptPassPhrase")]
        public string PassPhrase { get; set; }

        public string SmtpServer { get; set; }

        public int SmtpPort { get; set; }

        public string StandardEmpfaenger { get; set; }
    }
}
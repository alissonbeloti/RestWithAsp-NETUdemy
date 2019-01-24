using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace RestWithAsp_NETUdemy.Security.Configuration
{
    public class SigninConfiguration
    {
        public SigninConfiguration()
        {
            using (var provider = new RSACryptoServiceProvider(2048)) {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
        public SecurityKey Key { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}

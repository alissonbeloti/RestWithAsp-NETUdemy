using RestWithAsp_NETUdemy.Business;
using RestWithAsp_NETUdemy.Data.VO;
using RestWithAsp_NETUdemy.Model;
using RestWithAsp_NETUdemy.Repository;
using RestWithAsp_NETUdemy.Repository.Generic;
using RestWithAsp_NETUdemy.Security.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
//using System.Security.Principal;

namespace RestWithAsp_NETUdemy.Services.Business
{
    public class LoginBusiness : ILoginBusiness
    {
        private IUserRepository repository;
        private SigninConfiguration  signinConfiguration;
        private TokenConfiguration tokenConfiguration;

        public LoginBusiness(IUserRepository repository, SigninConfiguration signinConfiguration, TokenConfiguration tokenConfiguration)
        {
            this.repository = repository;
            this.signinConfiguration = signinConfiguration;
            this.tokenConfiguration = tokenConfiguration;
        }

        public object FindByLogin(UserVO user)
        {
            bool credentialsValid = false;
            
            if (user != null && !string.IsNullOrEmpty(user.Login))
            {
                var baseUser = repository.FindByLogin(user.Login);
                credentialsValid = (baseUser != null && user.Login == baseUser.Login && baseUser.AccessKey == user.AccessKey);
            }
            if (credentialsValid)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Login, "Login"),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Login),
                        }
                    );
                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(tokenConfiguration.Seconds);
                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);
                return SuccessObject(createDate, expirationDate, token);
            }
            else
            {
                return ExceptionObject();
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = tokenConfiguration.Issue,
                Audience = tokenConfiguration.Audience,
                SigningCredentials = signinConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });
            return handler.WriteToken(securityToken);
        }

        private object ExceptionObject()
        {
            return new
            {
                autenticated = true,
                message = "Falha na autenticação."
            };
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token)
        {
            return new
            {
                autenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }
    }
}

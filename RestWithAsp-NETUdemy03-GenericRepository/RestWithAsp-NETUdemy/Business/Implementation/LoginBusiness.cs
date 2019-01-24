using RestWithAsp_NETUdemy.Business;
using RestWithAsp_NETUdemy.Model;
using RestWithAsp_NETUdemy.Repository;
using RestWithAsp_NETUdemy.Repository.Generic;
using System;

namespace RestWithAsp_NETUdemy.Services.Business
{
    public class LoginBusiness : ILoginBusiness
    {
        private IUserRepository repository;
        //private readonly PersonConverter converter;

        public LoginBusiness(IUserRepository repository) {
            this.repository = repository;
        }

        public User FindByLogin(User user)
        {
            var user_ = repository.FindByLogin(user.Login);
            return user_;
        }
    }
}

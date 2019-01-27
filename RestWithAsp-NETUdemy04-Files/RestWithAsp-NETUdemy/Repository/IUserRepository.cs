using RestWithAsp_NETUdemy.Model;
using System.Collections.Generic;

namespace RestWithAsp_NETUdemy.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}

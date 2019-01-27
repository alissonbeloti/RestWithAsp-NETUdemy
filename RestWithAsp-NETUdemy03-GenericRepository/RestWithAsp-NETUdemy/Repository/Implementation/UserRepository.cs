using RestWithAsp_NETUdemy.Model;
using RestWithAsp_NETUdemy.Model.Context;
using System.Linq;

namespace RestWithAsp_NETUdemy.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private MySqlContext context;
        public UserRepository(MySqlContext context) {
            this.context = context;
        }

        public volatile int count;

        public User FindByLogin(string login)
        {
            return context.Users.FirstOrDefault(x => x.Login == login);
        }
    }
}

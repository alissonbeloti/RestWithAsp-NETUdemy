using RestWithAsp_NETUdemy.Model;

namespace RestWithAsp_NETUdemy.Business
{
    public interface ILoginBusiness
    {
        User FindByLogin(User user);
    }
}

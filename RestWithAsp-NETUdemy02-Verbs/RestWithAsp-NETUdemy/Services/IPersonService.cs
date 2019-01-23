using RestWithAsp_NETUdemy.Model;
using System.Collections.Generic;

namespace RestWithAsp_NETUdemy.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}

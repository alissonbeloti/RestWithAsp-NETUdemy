using RestWithAsp_NETUdemy.Model;
using RestWithAsp_NETUdemy.Model.Base;
using System.Collections.Generic;

namespace RestWithAsp_NETUdemy.Repository.Generic
{
    public interface IPersonRepository: IRepository<Person>
    {
        List<Person> FindByName(string firstName, string lastName);
    }
}

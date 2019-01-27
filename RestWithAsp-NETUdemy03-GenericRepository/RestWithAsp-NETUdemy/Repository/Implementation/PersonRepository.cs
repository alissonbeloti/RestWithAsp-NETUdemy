using RestWithAsp_NETUdemy.Model;
using RestWithAsp_NETUdemy.Model.Context;
using RestWithAsp_NETUdemy.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAsp_NETUdemy.Repository.Implementation
{
    //Para que não ter que implementar todos os metodos de repository foi utilizado o Generic, que já contém as implementações
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(MySqlContext context) :base(context) {}

        public List<Person> FindByName(string firstName, string lastName)
        {
            firstName = firstName.ToUpper();
            lastName = lastName.ToUpper();
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return context.Persons.Where(x => x.FirstName.ToUpper().Equals(firstName) && x.LastName.ToUpper().Equals(lastName)).ToList();
            }
            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return context.Persons.Where(x => x.FirstName.ToUpper().Equals(firstName)).ToList();
            }
            else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return context.Persons.Where(x => x.LastName.ToUpper().Equals(lastName)).ToList();
            }
            else
            {
                return new List<Person>();
            }
        }
    }
}

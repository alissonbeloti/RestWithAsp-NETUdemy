using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestWithAsp_NETUdemy.Model;

namespace RestWithAsp_NETUdemy.Services.Implementation
{
    public class PersonService : IPersonService
    {
        public volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            

        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person()
            {
                Id = IncrementAndGet(),
                FirstName = "João " + i,
                LastName = "Silva" + i,
                Address = "Rua que sobe desce, nunca aparece" + i,
                Gender = "Male",
            };
        }

        private long IncrementAndGet()
        {
            return  Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return new Person() {
                Id = IncrementAndGet(),
                FirstName  = "Edivania",
                LastName = "Silva",
                Address = "Rua que sobe desce, nunca aparece",
                Gender = "Male",
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}

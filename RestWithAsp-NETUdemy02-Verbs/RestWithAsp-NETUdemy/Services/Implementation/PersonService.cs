using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestWithAsp_NETUdemy.Model;
using RestWithAsp_NETUdemy.Model.Context;

namespace RestWithAsp_NETUdemy.Services.Implementation
{
    public class PersonService : IPersonService
    {
        private MySqlContext context;
        public PersonService(MySqlContext context) {
            this.context = context;
        }

        public volatile int count;

        public Person Create(Person person)
        {
            try
            {
                context.Add(person);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            context.Persons.Remove(context.Persons.Single(x => x.Id == id));
        }

        public List<Person> FindAll()
        {
            return context.Persons.ToList();
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
            return context.Persons.SingleOrDefault(x => x.Id == id);
        }

        public Person Update(Person person)
        {
            //var personAtualizar = context.Persons.SingleOrDefault(x => x.Id == person.Id);
            //personAtualizar.Address = person.Address;
            //personAtualizar.FirstName = person.FirstName;
            //personAtualizar.Gender = person.Gender;
            //personAtualizar.LastName = person.LastName;
            context.Entry<Person>(person).State = EntityState.Modified;
            context.SaveChanges();
            return person;
        }
    }
}

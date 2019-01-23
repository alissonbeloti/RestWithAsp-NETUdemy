using Microsoft.EntityFrameworkCore;
using RestWithAsp_NETUdemy.Business;
using RestWithAsp_NETUdemy.Model;
using RestWithAsp_NETUdemy.Model.Context;
using RestWithAsp_NETUdemy.Repository;
using RestWithAsp_NETUdemy.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithAsp_NETUdemy.Services.Business
{
    public class PersonBusiness : IPersonBusiness
    {
        private IPersonRepository repository;
        public PersonBusiness(IPersonRepository repository) {
            this.repository = repository;
        }

        public volatile int count;

        public Person Create(Person person)
        {
            
            return repository.Create(person);
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return repository.FindAll();
        }

        public Person FindById(long id)
        {
            return repository.FindById(id);
        }

        public Person Update(Person person)
        {
            return repository.Update(person);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RestWithAsp_NETUdemy.Business;
using RestWithAsp_NETUdemy.Data.Converters;
using RestWithAsp_NETUdemy.Data.VO;
using RestWithAsp_NETUdemy.Model;
using RestWithAsp_NETUdemy.Model.Context;
using RestWithAsp_NETUdemy.Repository;
using RestWithAsp_NETUdemy.Repository.Generic;
using RestWithAsp_NETUdemy.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithAsp_NETUdemy.Services.Business
{
    public class PersonBusiness : IPersonBusiness
    {
        private IRepository<Person> repository;
        private readonly PersonConverter converter;

        public PersonBusiness(IRepository<Person> repository) {
            this.repository = repository;
            this.converter = new PersonConverter();
        }

        public volatile int count;

        public PersonVO Create(PersonVO person)
        {
            var personEntity = this.converter.Parse(person);
            personEntity = repository.Create(personEntity);
            return this.converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return this.converter.ParseList(repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return this.converter.Parse(repository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = this.converter.Parse(person);
            personEntity = repository.Update(personEntity);
            return this.converter.Parse(personEntity);
        }
    }
}

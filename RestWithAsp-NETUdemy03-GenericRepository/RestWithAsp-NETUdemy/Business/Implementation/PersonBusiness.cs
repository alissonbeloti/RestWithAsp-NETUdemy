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
using Tapioca.HATEOAS.Utils;

namespace RestWithAsp_NETUdemy.Services.Business
{
    public class PersonBusiness : IPersonBusiness
    {
        private IPersonRepository repository;
        private readonly PersonConverter converter;
        public PagedSearchDTO<PersonVO> FindWithPaged(string name, string sortDirection, int pageSize, int page)
        {
            string query = @"Select * From Person p 
                            Where 1=1 ";
            if (!string.IsNullOrEmpty(name)) query += $" AND p.name like '%{name}%'";
            query += $" Order By p.name {sortDirection} limit {pageSize} offset {page}"; //$ dá para colocar a variável no meio... minha vida inteira com .Net e não sabia disso.

            var persons = converter.ParseList(repository.FindWhitePaged(query));

            string countQuery = @"Select count(1) From Person p 
                            Where 1=1 ";
            if (!string.IsNullOrEmpty(name)) query += $" AND p.name like '%{name}%'";
            countQuery += $" Order By p.name {sortDirection} limit {pageSize} offset {page}"; //$ dá para colocar a variável no meio... minha vida inteira com .Net e não sabia disso.

            int totalResults = repository.GetCount(countQuery);
            
            return new PagedSearchDTO<PersonVO>() {
                CurrentPage = page,
                List = persons,
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };
        }
        public PersonBusiness(IPersonRepository repository) {
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

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return this.converter.ParseList(repository.FindByName(firstName, lastName));
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

using Microsoft.EntityFrameworkCore;
using RestWithAsp_NETUdemy.Business;
using RestWithAsp_NETUdemy.Model;
using RestWithAsp_NETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithAsp_NETUdemy.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        private MySqlContext context;
        public BookRepository(MySqlContext context) {
            this.context = context;
        }

        public Book Create(Book book)
        {
            try
            {
                context.Add(book);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return book;
        }

        public void Delete(long id)
        {
            context.Books.Remove(context.Books.Single(x => x.Id == id));
        }

        public List<Book> FindAll()
        {
            return context.Books.ToList();
        }


        public Book FindById(long id)
        {
            return context.Books.SingleOrDefault(x => x.Id == id);
        }

        public Book Update(Book book)
        {
            //var personAtualizar = context.Persons.SingleOrDefault(x => x.Id == person.Id);
            //personAtualizar.Address = person.Address;
            //personAtualizar.FirstName = person.FirstName;
            //personAtualizar.Gender = person.Gender;
            //personAtualizar.LastName = person.LastName;
            context.Entry<Book>(book).State = EntityState.Modified;
            context.SaveChanges();
            return book;
        }
    }
}

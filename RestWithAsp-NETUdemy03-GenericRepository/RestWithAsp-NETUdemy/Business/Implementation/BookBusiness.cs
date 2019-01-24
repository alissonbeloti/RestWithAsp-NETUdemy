using RestWithAsp_NETUdemy.Model;
using RestWithAsp_NETUdemy.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NETUdemy.Business.Implementation
{
    public class BookBusiness: IBookBusiness
{
        private IRepository<Book> repository;
        public BookBusiness(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        public volatile int count;

        public Book Create(Book book)
        {

            return repository.Create(book);
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return repository.FindAll();
        }

        public Book FindById(long id)
        {
            return repository.FindById(id);
        }

        public Book Update(Book book)
        {
            return repository.Update(book);
        }
    }
}

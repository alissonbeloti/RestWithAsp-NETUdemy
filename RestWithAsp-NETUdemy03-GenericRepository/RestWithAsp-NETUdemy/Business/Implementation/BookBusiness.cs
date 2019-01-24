using RestWithAsp_NETUdemy.Data.Converters;
using RestWithAsp_NETUdemy.Data.VO;
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
        private readonly BookConverter converter;
        public BookBusiness(IRepository<Book> repository)
        {
            this.repository = repository;
            this.converter = new BookConverter();
        }

        public volatile int count;

        public BookVO Create(BookVO book)
        {
            var bookEntity = converter.Parse(book);
            return converter.Parse(repository.Create(bookEntity));
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return converter.ParseList(repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return converter.Parse(repository.FindById(id));
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = converter.Parse(book);
            return this.converter.Parse(repository.Update(bookEntity));
        }
    }
}

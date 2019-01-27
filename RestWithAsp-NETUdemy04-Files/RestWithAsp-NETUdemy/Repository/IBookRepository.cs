using RestWithAsp_NETUdemy.Model;
using System.Collections.Generic;

namespace RestWithAsp_NETUdemy.Repository
{
    public interface IBookRepository
    {
        Book Create(Book person);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book person);
        void Delete(long id);
    }
}

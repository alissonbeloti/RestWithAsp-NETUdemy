using RestWithAsp_NETUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithAsp_NETUdemy.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}

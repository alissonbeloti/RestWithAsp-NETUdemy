using System.Collections.Generic;
using RestWithAsp_NETUdemy.Data.Converter;
using RestWithAsp_NETUdemy.Data.VO;
using RestWithAsp_NETUdemy.Model;

namespace RestWithAsp_NETUdemy.Data.Converters
{
    public class BookConverter : Iparser<BookVO, Book>, Iparser<Book, BookVO>
    {
        public Book Parse(BookVO origem)
        {
            if (origem == null) return new Book();
            return new Book()
            {
                Author = origem.Author,
                Id = origem.Id,
                LaunchDate = origem.LaunchDate,
                Price = origem.Price,
                Title = origem.Title
            };
        }

        public BookVO Parse(Book origem)
        {
            if (origem == null) return new BookVO();
            return new BookVO()
            {
                Author = origem.Author,
                Id = origem.Id,
                LaunchDate = origem.LaunchDate,
                Price = origem.Price,
                Title = origem.Title
            };
        }

        public List<Book> ParseList(List<BookVO> origem)
        {
            if (origem == null) return new List<Book>();
            var lista = new List<Book>();
            foreach (var item in origem)
            {
                lista.Add(Parse(item));
            }
            return lista;
        }

        public List<BookVO> ParseList(List<Book> origem)
        {
            if (origem == null) return new List<BookVO>();
            var lista = new List<BookVO>();
            foreach (var item in origem)
            {
                lista.Add(Parse(item));
            }
            return lista;
        }
    }
}

using System.Collections.Generic;
using RestWithAsp_NETUdemy.Data.Converter;
using RestWithAsp_NETUdemy.Data.VO;
using RestWithAsp_NETUdemy.Model;

namespace RestWithAsp_NETUdemy.Data.Converters
{
    public class PersonConverter : Iparser<PersonVO, Person>, Iparser<Person,PersonVO>
    {
        public Person Parse(PersonVO origem)
        {
            if (origem == null) return new Person();
            return new Person()
            {
                Address = origem.Address,
                FirstName = origem.FirstName,
                Gender = origem.Gender,
                Id = origem.Id,
                LastName = origem.LastName
            };
        }

        public PersonVO Parse(Person origem)
        {
            if (origem == null) return new PersonVO();
            return new PersonVO()
            {
                Address = origem.Address,
                FirstName = origem.FirstName,
                Gender = origem.Gender,
                Id = origem.Id,
                LastName = origem.LastName
            };
        }

        public List<Person> ParseList(List<PersonVO> origem)
        {
            if (origem == null) return new List<Person>();
            var lista = new List<Person>();
            foreach (var item in origem)
            {
                lista.Add(Parse(item));
            }
            return lista;
        }

        public List<PersonVO> ParseList(List<Person> origem)
        {
            if (origem == null) return new List<PersonVO>();
            var lista = new List<PersonVO>();
            foreach (var item in origem)
            {
                lista.Add(Parse(item));
            }
            return lista;
        }
    }
}

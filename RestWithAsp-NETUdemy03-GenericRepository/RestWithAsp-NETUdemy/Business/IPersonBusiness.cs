using RestWithAsp_NETUdemy.Data.VO;
using RestWithAsp_NETUdemy.Model;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace RestWithAsp_NETUdemy.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindByName(string firstName, string lastName);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
        PagedSearchDTO<PersonVO> FindWithPaged(string name, string sortDirection, int pageSize, int page);
    }
}

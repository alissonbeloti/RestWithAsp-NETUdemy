﻿using RestWithAsp_NETUdemy.Model;
using System.Collections.Generic;

namespace RestWithAsp_NETUdemy.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}

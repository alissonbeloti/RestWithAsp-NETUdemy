﻿using RestWithAsp_NETUdemy.Data.VO;
using RestWithAsp_NETUdemy.Model;

namespace RestWithAsp_NETUdemy.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(UserVO user);
    }
}

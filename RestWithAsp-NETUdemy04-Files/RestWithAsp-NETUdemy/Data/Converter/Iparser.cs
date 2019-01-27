using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NETUdemy.Data.Converter
{
    public interface Iparser<O, D>
    {
        D Parse(O origem);
        List<D> ParseList(List<O> origem);
    }
}
